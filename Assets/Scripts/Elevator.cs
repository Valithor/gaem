using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public CharacterController controller;
    public float elevatorSpeed = 5f;
    private bool isRunning = false;
    public float distance = 20f;
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
            isRunning = false;
        }
        else if (isRunningLeft && transform.position.z <= leftPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = transform.right * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
            controller.Move(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controller = other.gameObject.GetComponent<CharacterController>();
            Debug.Log("Player wszedł na windę.");

            if (transform.position.z >= rightPosition)
            {
                isRunningLeft = true;
                isRunningRight = false;
                elevatorSpeed = -elevatorSpeed;
            }
            else if (transform.position.z <= leftPosition)
            {
                isRunningRight = true;
                isRunningLeft = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
        }
    }
}