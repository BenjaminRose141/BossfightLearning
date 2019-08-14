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

    public Transform food;


    [SerializeField]
    public LayerMask foodItemsLayer;        //public right now, should go onto Scriptable Object and be handled with Getter Setter there
    [SerializeField]
    public float viewRange = 0;
    [SerializeField]
    public string foodItemsTag = null;
    public NavMeshAgent navMeshAgent = null;

    private void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        //this.stateMachine.ChangeState(new State1_SearchFor(foodItemsLayer, this.gameObject, viewRange, foodItemsTag, this.FoodFound));
        this.StateMachine.ChangeState(new State1_Awake(this));
    }

    private void Update()
    {
        StateMachine.ExecuteStateUpdate();
    }

    public void FoodFound(SearchResult searchResult)
    {
        var foundFoodItems = searchResult.allHitObjectsWithRequiredTag;
    }

    public void ChooseBehaviourAfterIdle(SearchResult searchResult)
    {
        var foundFoodItems = searchResult.allHitObjectsWithRequiredTag;
        
        Debug.Log("Choosing After Idle");
        if(foundFoodItems.Count > 0)
        {
            Debug.Log("not empty" + foundFoodItems.Count);
            food = foundFoodItems[0].gameObject.transform;
        }
        else Debug.Log("Empty");


        if(foundFoodItems.Count > 0)
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
