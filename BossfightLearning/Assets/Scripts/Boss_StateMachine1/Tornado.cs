using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Tornado : MonoBehaviour
{
    private Statemachine1 stateMachine = new Statemachine1();
    public NavMeshAgent navMeshAgent = null;

    public AnimationClip awake;

    public Statemachine1 StateMachine { get => stateMachine; set => stateMachine = value; }

    private void Awake()
    {
    }

    private void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        this.StateMachine.ChangeState(new State1_Awake_Tornado(this));
    }

    private void Update()
    {
        StateMachine.ExecuteStateUpdate();
    }

    public void ChooseNewPosition()
    {
        Vector3 randomOffset = new Vector3(x : Random.Range(-10,10),y:0, z: Random.Range(-10,10));
        var destination = transform.position + randomOffset;
        navMeshAgent.SetDestination(destination);
    }
}
