using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado_Feedback : Feedback
{
   //Animation Data (individual Scriptable Object?)
    [SerializeField]
    private Animator animator = null;
    [SerializeField]
    private AnimationClip awake;
    
    private Tornado actor = null;

    //Particles
    [SerializeField]
    GameObject attackParticlesPrefab = null;

    //Objects
    [SerializeField]
    GameObject meteorPrefab = null;

    //Material
    public Material material; 

    private void Start()
    {
        actor = this.gameObject.GetComponent<Tornado>();

        //add nullchecks!
    }

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
            case "wander":
            PlayWander();
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

    private void PlayWander()
    {
        Debug.Log("PlayingIdleAnimation");
    }
    /* 
    public void SpawnMeteor()
    {
        GameObject meteorInstance = Instantiate(meteorPrefab, actor.food) as GameObject;
        ParticleSystem parts = meteorInstance.GetComponent<ParticleSystem>();
        float totalDuration = parts.main.duration + parts.main.startLifetime.constant + parts.main.startDelay.constant;
        Destroy(meteorInstance, totalDuration);
    }
    */
}
