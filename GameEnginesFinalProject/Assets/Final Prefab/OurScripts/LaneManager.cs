using UnityEngine;

public class LaneManager : MonoBehaviour
{
    public static LaneManager instance;

    [System.Serializable]
    public class Lane
    {
        public string laneName;
        public Transform[] waypoints;
    }

    public Lane[] lanes;

    private void Awake()
    {
        instance = this;
    }

    public Lane GetRandomLane()
    {
        return lanes[Random.Range(0, lanes.Length)];
    }
}
