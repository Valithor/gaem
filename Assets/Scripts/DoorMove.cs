using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    public float elevatorSpeed = 5f;
    private bool isRunning = false;
    public float distance = 2f;
    private bool isRunningRight = true;
    private bool isRunningLeft = false;
    private float leftPosition;
    private float rightPosition;

    void Start()
    {
        rightPosition = transform.position.z + distance;
        leftPosition = transform.position.z;
    }

    void Update()
    {
        if (isRunningRight && transform.position.z >= rightPosition)
        {
            isRunningLeft = true;
            isRunningRight = false;
            isRunning = false;
            elevatorSpeed = -elevatorSpeed;
        }
        else if (isRunningLeft && transform.position.z <= leftPosition)
        {
            isRunningLeft = false;
            isRunningRight = true;
            isRunning = false;
            elevatorSpeed = Mathf.Abs(elevatorSpeed);
        }

        if (isRunning)
        {
            Vector3 move = new Vector3(0, 0, 1) * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
        
           
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isRunning = true;
            Debug.Log("Player zszedł z windy.");
        }
    }
}