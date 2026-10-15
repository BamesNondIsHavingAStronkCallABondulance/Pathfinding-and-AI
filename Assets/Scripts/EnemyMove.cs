using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    private List<Vector3> visitedNodes = new();
    public NodeTracker tracker;
    private Vector3 goal, testGoal;
    private NavMeshAgent agent;
    private bool foundNode = false, searchingForNode = true;
    private float maxNodeDistance = 10f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!foundNode)
        {
            FindNewNode();
        }

        if (transform.position.x == goal.x && transform.position.z == goal.z)
        {
            foundNode = false;
            searchingForNode = true;
        }
    }

    private void FindNewNode()
    {
        while (searchingForNode)
        {
            //add has been visited
            searchingForNode = false;

            goal = tracker.nodePositions.ElementAt(Random.Range(0, tracker.nodePositions.Count));
            Debug.Log(goal);

            Vector3 offset = goal - transform.position;
            float sqrLen = offset.sqrMagnitude;

            if (sqrLen < maxNodeDistance * maxNodeDistance)
            {
                foreach (Vector3 i in visitedNodes)
                {
                    if (i == goal)
                    {
                        searchingForNode = true;
                    }
                    Debug.Log("visited node is" + i);
                }
            }
        }

        agent.destination = goal;
        visitedNodes.Add(goal);
        foundNode = true;
    }
}
