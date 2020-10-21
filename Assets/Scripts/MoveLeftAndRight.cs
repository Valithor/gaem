using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftAndRight : MonoBehaviour
{
    public float force = 5.0f;
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 posDiff = new Vector3(10f, 0f, 0f);

    void Start()
    {
        posA = transform.position;
        posB = transform.position + posDiff;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(posA, posB, Mathf.PingPong(Time.time * force, 1.0f));
        transform.Rotate(Vector3.up * 10f * Time.deltaTime);
    }
}
