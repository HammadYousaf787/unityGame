using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowscript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("arrow collided with " + collision.gameObject.tag);
        // Check if the arrow hits a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Make the arrow a child of the wall
            
            // Optionally disable further physics interactions
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
        }
    }
}
