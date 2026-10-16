using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class EnemyScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 currentPosition;
    public CollectionOfNodes collection;

    public Animator animator;
    StateMachine sm;

    public Vector3 goal;

    public List<Node> nodes = new();


    void Start()
    {
        nodes = collection.nodeList;

        animator = GetComponent<Animator>();
        sm = new StateMachine(this);

        sm.Init(sm.PatrolState);
      

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        //do not put any of your own methods here - they go in the individual state files
        sm.Update();
    }

}
