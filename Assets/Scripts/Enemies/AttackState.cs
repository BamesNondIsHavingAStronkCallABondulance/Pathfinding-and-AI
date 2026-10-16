using UnityEngine;

public class AttackState : State
{
    //public EnemyPatrol enemyPatrol;
    public FieldOfView fov;


    public AttackState(EnemyScript enemy, StateMachine sm) : base(enemy, sm)
    {
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }
}
