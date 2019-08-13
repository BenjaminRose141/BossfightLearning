using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class State1_Awake_Tornado : IState1
{
    Tornado actor;
    bool animationFinished;

    public State1_Awake_Tornado(Tornado actor)
    {
        this.actor = actor;
    }

    public void Enter()
    {
        Debug.Log(actor.gameObject.name + " Awakening");
        actor.StartCoroutine(PlayAwake());
    }

    public IEnumerator PlayAwake()
    {
       actor.gameObject.GetComponent<Tornado_Feedback>().NewStateAnimation("awake");
       animationFinished = false;
       yield return new WaitForSeconds(actor.awake.length);
       animationFinished = true;
       yield break;
    }

    public void Execute()
    {
        if(animationFinished)
        {
            //Go into Idle
            actor.StateMachine.ChangeState(new State1_Wander_Tornado(actor, actor.navMeshAgent));
        }
    }
    public void Exit()
    {

    }
}
