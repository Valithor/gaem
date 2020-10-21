using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSquare : MonoBehaviour
{
    public float force = 5.0f;
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 posC;
    private Vector3 posD;
    private Vector3 posDiff = new Vector3(10f, 0f, 0f);
    private Vector3 posDiff2 = new Vector3(0f, 0f, 10f);
    int side = 1;
  
    void Start()
    {
        posA = transform.position;
        posB = transform.position + posDiff;
        posC = transform.position + posDiff + posDiff2;
        posD = transform.position + posDiff2;

    }

    void FixedUpdate()
    {

      
        transform.Translate(Vector2.right * force * Time.deltaTime);        
   
        if (side == 1 && transform.position.x >= posB.x)
        {
            transform.rotation *= Quaternion.Euler(0, -90, 0);
            side = 2;
        }
        if(side==2 && transform.position.z >= posC.z)
        {
            transform.rotation *= Quaternion.Euler(0, -90, 0);
            side = 3;
        }
        if (side == 3 && transform.position.x <= posD.x)
        {
            transform.rotation *= Quaternion.Euler(0, -90, 0);
            side = 4;
        }
        if (side == 4 && transform.position.z <= posA.z)
        {
            transform.rotation *= Quaternion.Euler(0, -90, 0);
            side = 1;
        }
    }
}
