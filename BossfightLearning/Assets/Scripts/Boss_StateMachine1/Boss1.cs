using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Boss1 : MonoBehaviour
{
    private Statemachine1 stateMachine = new Statemachine1();

    [SerializeField]
    private LayerMask foodItemsLayer;
    [SerializeField]
    private float viewRange;
    [SerializeField]
    private string foodItemsTag;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        this.stateMachine.ChangeState(new State1_SearchFor(foodItemsLayer, this.gameObject, viewRange, foodItemsTag, navMeshAgent));
    }

    private void Update()
    {
        stateMachine.ExecuteStateUpdate();
    }

}
