using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    private Rigidbody _rigidbody;
    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(1, 0, 0);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //playerVelocity.y += Mathf.Sqrt(jumpHeight * 3.0f * -3.0f * gravityValue);
            //playerVelocity.y += gravityValue * Time.deltaTime;
            //controller.Move(playerVelocity * Time.deltaTime);
            Debug.Log("Player zderzył się z kostką.");
        }
    }
  
}
