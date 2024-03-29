﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State1_Idle : IState1
{
    float timerStart = 10;
    float timerCurrent = 0;
    Boss1 actor;

    public State1_Idle(Boss1 actor)
    {
        this.actor = actor;
    }

    public void Enter()
    {
        Debug.Log("Now in Idle");
        //Animation Event
        timerStart = Random.Range(4,10);
        Debug.Log("Timer: " + timerStart);
        timerCurrent = timerStart;
    }

    public void Execute()
    {
        timerCurrent -= Time.deltaTime;
        
        if(timerCurrent <= 0)
        {
            timerCurrent = timerStart;
            ChooseBehaviour();
        }
    }

    private void ChooseBehaviour()
    {
        actor.StateMachine.ChangeState(new State1_SearchFor(actor.playerLayer, actor.gameObject, actor.viewRange, actor.playerTag, actor.ChooseBehaviourAfterIdle));
    }

    public void Exit()
    {

    }
}
