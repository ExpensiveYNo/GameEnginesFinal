using UnityEngine;

public class EnemyLaneAI : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public float waypointArrivalDistance = 0.5f;    // How close to get before moving to next waypoint

    [Header("Attack Settings")]
    public float attackRange = 2f;                  // How close to the base before stopping and attacking
    public float attackDamage = 10f;                // Damage dealt to base per tick
    public float attackInterval = 1f;               // Seconds between damage ticks

    private LaneManager.Lane assignedLane;
    private int currentWaypointIndex = 0;
    private bool isAttackingBase = false;
    private float attackTimer = 0f;
    private Transform baseTransform;

    void Start()
    {
        // Grab a random lane from the LaneManager
        assignedLane = LaneManager.instance.GetRandomLane();

        // Find the base
        GameObject baseObj = GameObject.FindWithTag("Base");
        if (baseObj != null)
            baseTransform = baseObj.transform;
        else
            Debug.LogWarning($"{gameObject.name}: No GameObject tagged 'Base' found!");
    }

    void Update()
    {
        if (isAttackingBase)
            AttackBase();
        else
            FollowLane();
    }

    void FollowLane()
    {
        if (assignedLane == null || assignedLane.waypoints.Length == 0) return;

        // Check if close enough to base to start attacking
        if (baseTransform != null && Vector3.Distance(transform.position, baseTransform.position) <= attackRange)
        {
            isAttackingBase = true;
            return;
        }

        // Move toward current waypoint
        Transform target = assignedLane.waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        // Face the direction of travel
        Vector3 direction = (target.position - transform.position).normalized;
        if (direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direction);

        // Advance to next waypoint on arrival
        if (Vector3.Distance(transform.position, target.position) <= waypointArrivalDistance)
        {
            if (currentWaypointIndex < assignedLane.waypoints.Length - 1)
                currentWaypointIndex++;
        }
    }

    void AttackBase()
    {
        // Face the base while attacking
        if (baseTransform != null)
        {
            Vector3 direction = (baseTransform.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction);
        }

        attackTimer += Time.deltaTime;
        if (attackTimer >= attackInterval)
        {
            attackTimer = 0f;
            Base baseHealth = baseTransform.GetComponent<Base>();
            if (baseHealth != null)
                baseHealth.TakeDamage(attackDamage);
        }
    }

    // Visualize attack range in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
