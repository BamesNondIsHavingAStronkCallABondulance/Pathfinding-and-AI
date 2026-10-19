using UnityEngine;

public class AttackState : State
{

    public AttackState(EnemyScript enemy, StateMachine sm) : base(enemy, sm)
    {
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        if (enemy.fieldOfView.canSeePlayer)
        {
            //enemy.goal = enemy.player.transform.position;
            Debug.Log("Sight");
        }
        else
        {
            sm.ChangeState(sm.PatrolState);
        }
    }
}
