using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Tornado : Actor
{

    public NavMeshAgent navMeshAgent = null;

    public AnimationClip awake;

    private void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        this.StateMachine.ChangeState(new State1_Awake_Tornado(this));
    }

    public void ChooseNewPosition()
    {
        Vector3 randomOffset = new Vector3(x : Random.Range(-10,10),y:0, z: Random.Range(-10,10));
        var destination = transform.position + randomOffset;
        navMeshAgent.SetDestination(destination);
    }
}
