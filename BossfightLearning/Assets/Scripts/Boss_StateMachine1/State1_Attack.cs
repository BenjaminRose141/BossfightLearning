using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State1_Attack : IState1
{
    private Boss1 actor;
    private bool animationFinished;
    public State1_Attack(Boss1 actor)
    {
        this.actor = actor;
    }

    public void Enter()
    {
        Debug.Log("now Attacking");
        animationFinished = false;
        actor.StartCoroutine(PlayAttack());
    }

    public IEnumerator PlayAttack()
    {
       actor.gameObject.GetComponent<Boss1_Feedback>().NewStateAnimation("attack");
       animationFinished = false;
       yield return new WaitForSeconds(actor.awake.length);
       animationFinished = true;
       yield break;
    }

    public void Execute()
    {
        if(animationFinished)
        {
            //Go back to Idle
            actor.StateMachine.ChangeState(new State1_Idle(actor));
        }
    }

    public void Exit()
    {

    }
}
