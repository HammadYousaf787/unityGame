using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class arrowscript : MonoBehaviour
{
    
    private Rigidbody rb;
    public float velocity;
    public TrailRenderer tail;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        
        // Check if the arrow hits a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb = GetComponent<Rigidbody>();
            // Make the arrow a child of the wall

            // Optionally disable further physics interactions

            Debug.Log("Wall hit");

            rb.isKinematic = true;
        }
        else if (collision.gameObject.CompareTag("head_enemy"))
        {
            // Make the arrow a child of the wall

            // Optionally disable further physics interactions
            rb = GetComponent<Rigidbody>();
            velocity = rb.velocity.magnitude;
            Transform enemyTransform = collision.transform;
            transform.SetParent(enemyTransform);
            
            Debug.Log("headShot!!");
            rb.isKinematic = true;
            tail.enabled = false;
        }
        else if (collision.gameObject.CompareTag("body_enemy"))
        {
            // Make the arrow a child of the wall

            // Optionally disable further physics interactions
            rb = GetComponent<Rigidbody>();
            velocity = rb.velocity.magnitude;
            Debug.Log(velocity);
            Transform enemyTransform = collision.transform;
            transform.SetParent(enemyTransform);
            Debug.Log("bodyShot!!!");
            rb.isKinematic = true;
            tail.enabled = false;
        }
        
    }
}
