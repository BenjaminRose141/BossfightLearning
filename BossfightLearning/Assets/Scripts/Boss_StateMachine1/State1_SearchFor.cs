using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State1_SearchFor : IState1
{
    private LayerMask searchLayer;
    private GameObject actorGameObject;
    private float searchRadius;
    private string tagToLookFor;
    private NavMeshAgent navMeshAgent;

    public State1_SearchFor(LayerMask searchLayer, GameObject actorGameObject, float searchRadius, string tagToLookFor, NavMeshAgent navMeshAgent)
    {
        this.searchLayer = searchLayer;
        this.actorGameObject = actorGameObject;
        this.searchRadius = searchRadius;
        this.tagToLookFor = tagToLookFor;
        this.navMeshAgent = navMeshAgent;
    }

    public void Enter()
    {

    }

    public void Execute()
    {
        Debug.Log("Executing SearchFor");
        var HitObjects = Physics.OverlapSphere(this.actorGameObject.transform.position, searchRadius);

        for (int i = 0; i < HitObjects.Length; i++)
        {
            Debug.Log("Searching " + i);

            if(HitObjects[i].CompareTag(this.tagToLookFor))
            {
                this.navMeshAgent.SetDestination(HitObjects[i].transform.position);
                Debug.Log("Found Object");
                break;
            }
            
        }
    }

    public void Exit()
    {

    }
}
