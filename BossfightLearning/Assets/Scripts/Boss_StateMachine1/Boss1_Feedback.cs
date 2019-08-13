using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_Feedback : MonoBehaviour
{
    //Animation Data (individual Scriptable Object?)
    [SerializeField] 
    private BossScriptableObject bossData;
    [SerializeField]
    private Animator animator = null;
    [SerializeField]
    private AnimationClip idle;
    
    private Boss1 actor = null;

    //Particles
    [SerializeField]
    GameObject attackParticlesPrefab;

    //Objects
    [SerializeField]
    GameObject meteorPrefab;

    //Material
    public Material material; 

    private void Start()
    {
        actor = this.gameObject.GetComponent<Boss1>();

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
        animator.Play("Attack");
        
        GameObject particleInstance = Instantiate(attackParticlesPrefab, actor.gameObject.transform.position, actor.gameObject.transform.rotation) as GameObject;
        ParticleSystem parts = particleInstance.GetComponent<ParticleSystem>();
        float totalDuration = parts.main.duration + parts.main.startLifetime.constant;
        Destroy(particleInstance, totalDuration);
    }

    public void SpawnMeteor()
    {
        GameObject meteorInstance = Instantiate(meteorPrefab, actor.food) as GameObject;
        ParticleSystem parts = meteorInstance.GetComponent<ParticleSystem>();
        float totalDuration = parts.main.duration + parts.main.startLifetime.constant + parts.main.startDelay.constant;
        Destroy(meteorInstance, totalDuration);
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
