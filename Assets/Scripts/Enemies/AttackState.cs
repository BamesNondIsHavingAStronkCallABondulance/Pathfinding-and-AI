using UnityEngine;

public class AttackState : EnemyState
{

    public AttackState(EnemyScript enemy, EnemyStateMachine sm) : base(enemy, sm)
    {
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        if (enemy.fieldOfView.canSeePlayer) //Want this to be in a coroutine to set timers
        {
            enemy.agent.destination = enemy.player.transform.position; //Need to check if player is colliding with safe zone
            Debug.Log("Sight");
        }
        else
        {
            Debug.Log("Leaving chase");
            sm.ChangeState(sm.patrolState);
        }
    }

    public override void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            enemy.playerMove.playerHealth -= 1;
            Debug.Log(enemy.playerMove.playerHealth);
        }
    }
}
