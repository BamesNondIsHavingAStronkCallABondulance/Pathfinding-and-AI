using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Unity.VisualScripting;

public class PatrolState : State //Pull from state not mono
{
    public PatrolState(EnemyScript enemy, StateMachine sm) : base(enemy, sm)
    {
    }

    private Node selectedNode;

    private bool foundNode = false, searchingForNode = true;
    float maxNodeRange = 20; //Should be modified for different enemies



    public override void Update()
    {
        if(!CheckForValidNodes())
        {
            ResetNodes();
            Debug.Log("Resetting Nodes");
        }

        if (!foundNode)
        {
            Debug.Log("Searching");
            SetGoal();
            FindNewNode();
        }

        float dist = Vector3.Distance(enemy.goal, enemy.transform.position);

        if (dist <= 2)
        {
            Debug.Log("Found");
            foundNode = false;
            searchingForNode = true;
        }
        else
        {
            Debug.Log(dist);
        }
    }

    private void SetGoal()
    {
        selectedNode = enemy.nodes[Random.Range(0, enemy.nodes.Count)];
        enemy.goal = selectedNode.pos;
    }

    private bool CheckForValidNodes()
    {
        float dist = Vector3.Distance(enemy.goal, enemy.transform.position);

        foreach (Node i in enemy.nodes)
        {
            if (i.visited == false && dist < maxNodeRange)
            {
                return true; //If at least one node is within range and unvisited
            }
        }

        return false;

    }

    private void FindNewNode()
    {
        while(searchingForNode)
        {
            float dist = Vector3.Distance(enemy.goal, enemy.currentPosition);

            if (dist < 20)
            {
                if (selectedNode.visited == false)
                {
                    searchingForNode = false;
                }
                else
                {
                    SetGoal();
                }
            }
            else
            {
                SetGoal();
            }

            //searchingForNode = false;
        }

        enemy.agent.destination = enemy.goal;
        selectedNode.visited = true;
        foundNode = true;
    }

    private void ResetNodes()
    {
        foreach(Node i in enemy.nodes)
        {
            i.visited = false;
        }
    }
}
