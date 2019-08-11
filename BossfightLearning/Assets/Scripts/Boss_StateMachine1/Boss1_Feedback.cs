using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_Feedback : MonoBehaviour
{
    //Animation Data (individual Scriptable Object?)
    [SerializeField] 
    private BossScriptableObject bossData;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private AnimationClip idle;

    //Material
    public Material material; 

    //Event?
    //new state animation (state)
    public void NewStateAnimation(string state)
    {
        //NOT REUSABLE --> Array?
        switch(state)
        {
            case "awake":
            PlayAwake();
            break;
            case "idle":
            PlayIdle();
            break;
            case "attack":
            PlayAttack();
            break;
            case null:
            Debug.Log("no State");
            return;
        }
    }

    private void PlayAwake()
    {
        Debug.Log("PlayingAwakeAnimation");
        animator.Play("Awake");
    }

    private void PlayIdle()
    {
        Debug.Log("PlayingIdleAnimation");
    }

    private void PlayAttack()
    {
        Debug.Log("PlayingAttackAnimation");
    }

 
    //switch
    //states


    //Functions

    /* 
    Renderer mat = actor.gameObject.GetComponent<Renderer>();
    actor.material.SetColor("_BaseColor", Color.red);
    mat.material = actor.material;

    Renderer mat = actor.gameObject.GetComponent<Renderer>();
    actor.material.SetColor("_BaseColor", Color.blue);
    mat.material = actor.material;

    Renderer mat = actorGameObject.GetComponent<Renderer>();
    actorGameObject.GetComponent<Boss1>().material.SetColor("_BaseColor", Color.yellow);
    mat.material = actorGameObject.GetComponent<Boss1>().material;
    
    */
}
