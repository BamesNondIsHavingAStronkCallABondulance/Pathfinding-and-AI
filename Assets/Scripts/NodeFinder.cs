using UnityEngine;

public class NodeFinder : MonoBehaviour
{
    public NodeTracker tracker;
    void Start()
    {
        tracker.nodePositions.Add(transform.position);
    }
}
