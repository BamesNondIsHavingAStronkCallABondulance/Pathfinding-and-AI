using UnityEngine;


//Handles initialisation of states, switching of states
//It handles calling Update and FixedUpdate for the currently active state

public class EnemyStateMachine
{
    public EnemyState currentState, lastState;

    //declare all states here
    public PatrolState patrolState;
    public AttackState attackState;
    //public SearchState SearchState;
    //public HurtState hurtState;
    //public DeathState deathState;


    //constructor
    public EnemyStateMachine( EnemyScript enemy )
    {
        //initialise all states here
        patrolState = new PatrolState(enemy, this);
        attackState = new AttackState(enemy, this);
    }

    public void Init(EnemyState startingState)
    {
        currentState = startingState;
        lastState = null;
        startingState.Enter();
    }

    public void ChangeState(EnemyState newState)
    {
        currentState.Exit();

        lastState = currentState;
        currentState = newState;
        newState.Enter();
    }

    public void Update()
    {
        currentState.Update();
    }

    public void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

}
