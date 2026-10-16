using UnityEngine;


//Handles initialisation of states, switching of states
//It handles calling Update and FixedUpdate for the currently active state

public class StateMachine
{
    public State currentState, lastState;

    //declare all states here
    public PatrolState PatrolState;
    public AttackState AttackState;
    //public SearchState SearchState;
    //public HurtState hurtState;
    //public DeathState deathState;


    //constructor
    public StateMachine( EnemyScript enemy )
    {
        //initialise all states here
        PatrolState = new PatrolState(enemy, this);
        AttackState = new AttackState(enemy, this);
    }

    public void Init(State startingState)
    {
        currentState = startingState;
        lastState = null;
        startingState.Enter();
    }

    public void ChangeState(State newState)
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
