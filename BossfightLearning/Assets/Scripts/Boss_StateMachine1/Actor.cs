using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    private Statemachine1 stateMachine = new Statemachine1();

    public Statemachine1 StateMachine { get => stateMachine; private set => stateMachine = value; }

    [SerializeField]
    private ScriptableObject actorData;

    public ScriptableObject ActorData { get => actorData; private set => actorData = value; }

    private void Update()
    {
        StateMachine.ExecuteStateUpdate();
    }
}
