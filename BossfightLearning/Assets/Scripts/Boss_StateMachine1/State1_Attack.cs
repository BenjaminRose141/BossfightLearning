using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State1_Attack : IState1
{
    private Boss1 actor;
    public State1_Attack(Boss1 actor)
    {
        this.actor = actor;
    }

    public void Enter()
    {
        Debug.Log("now Attacking");
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }
}
