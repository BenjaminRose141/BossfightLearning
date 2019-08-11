using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State1_Awake : IState1
{
    Boss1 actor;
    bool animationFinished;

    public State1_Awake(Boss1 actor)
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
       actor.gameObject.GetComponent<Boss1_Feedback>().NewStateAnimation("awake");
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
            actor.StateMachine.ChangeState(new State1_Idle(actor));
        }
    }
    public void Exit()
    {

    }
}
