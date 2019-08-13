using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State1_Wander_Tornado : IState1
{
    Tornado actor;
    NavMeshAgent navMeshAgent;

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
        actor.ChooseNewPosition();
    }
    
    public void Exit()
    {

    }

}