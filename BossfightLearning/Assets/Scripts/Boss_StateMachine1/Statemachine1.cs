using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statemachine1
{
    private IState1 currentState;
    private IState1 previousState;

    public void ChangeState(IState1 newState)
    {
        Debug.Log("ChangeState");
        if(currentState != null)
        {
            currentState.Exit();
        }

        previousState = currentState;
        currentState = newState;
        currentState.Enter();
    }

    public void ExecuteStateUpdate()
    {
        Debug.Log("ExecuteStateUpdate");
        if(currentState != null)
        {
            currentState.Execute();
        }
    }
}
