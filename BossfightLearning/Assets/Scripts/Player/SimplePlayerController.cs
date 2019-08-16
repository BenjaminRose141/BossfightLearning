using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    public float forwardVelocity;
    public float rotateVelocity;
    private Quaternion targetRotation;
    private Rigidbody rigidBody;
    float forwardInput;
    float turnInput;
    public Quaternion TargetRotation
    {
        get { return targetRotation;}
    }


    void Start()
    {
        targetRotation = transform.rotation;
        rigidBody = GetComponent<Rigidbody>();
        forwardInput = turnInput = 0f;
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    void Update()
    {
        GetInput();
        Turn();
    }

    void FixedUpdate()
    {
        Run();
    }

    void Run()
    {
        rigidBody.velocity = transform.forward * forwardInput * forwardVelocity;
    }

    void Turn()
    {
        targetRotation *= Quaternion.AngleAxis(rotateVelocity*turnInput*Time.deltaTime, Vector3.up);
        transform.rotation = targetRotation;
    }

}