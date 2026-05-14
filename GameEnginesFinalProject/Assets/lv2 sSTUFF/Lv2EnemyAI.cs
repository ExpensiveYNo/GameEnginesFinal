using UnityEngine;
using UnityEngine.AI;

public class Lv2EnemyAI : MonoBehaviour
{
    public Transform[] patrolPoints = new Transform[4];
    public Transform player;

    public float viewRange = 10f;
    public float viewAngle = 120f;
    public float losePlayerDelay = 3f;

    private NavMeshAgent agent;
    private int currentPoint;
    private float lostTimer;
    private bool chasing;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GoToNextPoint();
    }

    void Update()
    {
        if (CanSeePlayer())
        {
            chasing = true;
            lostTimer = 0f;
        }
        else if (chasing)
        {
            lostTimer += Time.deltaTime;
            if (lostTimer >= losePlayerDelay)
            {
                chasing = false;
                GoToNextPoint();
            }
        }

        if (chasing)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GoToNextPoint();
        }
    }

    bool CanSeePlayer()
    {
        Vector3 dir = (player.position - transform.position);
        float dist = dir.magnitude;

        if (dist > viewRange) return false;

        float angle = Vector3.Angle(transform.forward, dir.normalized);
        if (angle > viewAngle * 0.5f) return false;

        if (Physics.Raycast(transform.position + Vector3.up, dir.normalized, out RaycastHit hit, viewRange))
        {
            return hit.transform == player;
        }

        return false;
    }

    void GoToNextPoint()
    {
        if (patrolPoints.Length == 0) return;

        agent.SetDestination(patrolPoints[currentPoint].position);
        currentPoint = (currentPoint + 1) % patrolPoints.Length;
    }
}