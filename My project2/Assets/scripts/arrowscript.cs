using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class arrowscript : MonoBehaviour
{
    
    private Rigidbody rb;
    public float velocity;
    public TrailRenderer tail;
    public bool isActive = true;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        
        // Check if the arrow hits a wall
        
        if (collision.gameObject.CompareTag("head_enemy"))
        {
            // Make the arrow a child of the wall

            // Optionally disable further physics interactions
            rb = GetComponent<Rigidbody>();
            velocity = rb.velocity.magnitude;
            Transform enemyTransform = collision.transform;
            transform.SetParent(enemyTransform);
            Collider arrowCollider = GetComponent<Collider>();
            arrowCollider.enabled = false;
            
            Debug.Log("headShot!!");
            rb.isKinematic = true;
            tail.enabled = false;
            isActive = false;
            StartCoroutine(DestroyArrowAfterDelay(3f));
        }
        else if (collision.gameObject.CompareTag("body_enemy"))
        {
            // Make the arrow a child of the wall

            // Optionally disable further physics interactions
            rb = GetComponent<Rigidbody>();
            Transform enemyTransform = collision.transform;
            transform.SetParent(enemyTransform);
            Collider arrowCollider = GetComponent<Collider>();
            arrowCollider.enabled = false;
            
            rb.isKinematic = true;

            
            tail.enabled = false;
            StartCoroutine(DestroyArrowAfterDelay(3f));
        }
        



    }


    private IEnumerator DestroyArrowAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Destroy the arrow GameObject
        Destroy(gameObject);
    }

}
