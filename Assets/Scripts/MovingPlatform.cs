using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] points;
    int destPoint;
    public float speed = 1f;

    // Use this for initialization
    void Start()
    {
        UpdateTarget();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 thisPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (Vector3.Distance(thisPos, points[destPoint].position) < speed)
        {
            UpdateTarget();
        }

        transform.position = Vector3.Lerp(transform.position, points[destPoint].position, 3 * Time.deltaTime);
    }

    void UpdateTarget()
    {
        if (points.Length == 0)
        {
            return;
        }
        transform.position = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;

    }
}