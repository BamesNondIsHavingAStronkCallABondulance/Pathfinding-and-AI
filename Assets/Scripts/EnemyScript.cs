using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class EnemyScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public FieldOfView fieldOfView;
    public Vector3 currentPosition;
    public CollectionOfNodes collection;

    public PlayerMove playerMove;
    public Animator animator;
    EnemyStateMachine sm;

    public Vector3 goal;

    public List<Node> nodes = new();

    public GameObject player;


    void Start()
    {
        player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMove>();

        nodes = collection.nodeList;

        animator = GetComponent<Animator>();
        sm = new EnemyStateMachine(this);

        sm.Init(sm.patrolState);
      

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        //do not put any of your own methods here - they go in the individual state files
        sm.Update();
    }

}
