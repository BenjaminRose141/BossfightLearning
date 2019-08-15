using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    private Statemachine1 stateMachine = new Statemachine1();

    public Statemachine1 StateMachine { get => stateMachine; private set => stateMachine = value; }

    [SerializeField]
    private CharacterScriptableObject actorData;

    public CharacterScriptableObject ActorData { get => actorData; private set => actorData = value; }

    private void Update()
    {
        StateMachine.ExecuteStateUpdate();
    }
}
