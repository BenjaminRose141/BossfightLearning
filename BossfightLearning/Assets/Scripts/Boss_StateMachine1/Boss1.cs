using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Boss1_Feedback))]
public class Boss1 : Actor
{
    [SerializeField] 
    public AnimationClip awake;
    [SerializeField] 
    public AnimationClip attack;

    public Transform player;


    [SerializeField]
    public LayerMask playerLayer;        //public right now, should go onto Scriptable Object and be handled with Getter Setter there
    [SerializeField]
    public float viewRange = 0;
    [SerializeField]
    public string playerTag = null;
    public NavMeshAgent navMeshAgent = null;

    private void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        //this.stateMachine.ChangeState(new State1_SearchFor(playerLayer, this.gameObject, viewRange, playerTag, this.FoodFound));
        this.StateMachine.ChangeState(new State1_Awake(this));
    }

    private void Update()
    {
        StateMachine.ExecuteStateUpdate();
    }

    public void PlayersFound(SearchResult searchResult)
    {
        var foundPlayers = searchResult.allHitObjectsWithRequiredTag;
    }

    public void ChooseBehaviourAfterIdle(SearchResult searchResult)
    {
        var foundPlayers = searchResult.allHitObjectsWithRequiredTag;
        
        Debug.Log("Choosing After Idle");
        if(foundPlayers.Count > 0)
        {
            Debug.Log("not empty " + foundPlayers.Count);
            player = foundPlayers[0].gameObject.transform;
        }
        else Debug.Log("Empty");


        if(foundPlayers.Count > 0)
        {
            //Choose which attack to choose by using info provided
            StateMachine.ChangeState(new State1_Attack(this));
        }
        else
        {
            StateMachine.ReturnToPreviousState();
        }
    }
}
