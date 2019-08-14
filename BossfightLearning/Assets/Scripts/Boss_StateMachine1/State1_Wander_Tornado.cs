using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State1_Wander_Tornado : IState1
{
    Tornado actor;
    NavMeshAgent navMeshAgent;
    float timerCurrent = 0;
    float timerMax = 3;

    public State1_Wander_Tornado(Tornado actor, NavMeshAgent navMeshAgent)
    {
        this.actor = actor;
        this.navMeshAgent = navMeshAgent;
    }

    public void Enter()
    {
        Debug.Log(actor.gameObject.name + " Awakening");
    }

    public void Execute()
    {
        //Coroutine instead of Timer?

        timerCurrent -= Time.deltaTime;
        if(timerCurrent <= 0)
        {
            actor.ChooseNewPosition();
            timerCurrent = timerMax;
        }

    }
    
    public void Exit()
    {

    }

}