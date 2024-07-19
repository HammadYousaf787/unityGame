using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update


    private Rigidbody rb;
    public float jumpForce;
    public bool groundcheck;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpForce = GetComponent<float>();
    }
    void OnCollisionEnter(Collision collision)
    {
        // Log the name of the object this object collided with
        Debug.Log("Collided with " + collision.gameObject.name);

        // Example: Check for a specific tag
        if (collision.gameObject.CompareTag("platform"))
        {
            Debug.Log("on a platform");
            groundcheck = true;
            // Perform actions like destroying the object or applying effects
            // Destroy(collision.gameObject);
        }
        else
        {
            groundcheck = false;
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered by " + other.gameObject.name);
    }
    void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            Vector3 newPosition = transform.localPosition;
            newPosition.x += 1;
            transform.localPosition = newPosition;
        }
        if (Input.GetKeyDown("a"))
        {
            Vector3 newPosition = transform.localPosition;
            newPosition.x -= 1;
            transform.localPosition = newPosition;
        }
        if (Input.GetKeyDown("w"))
        {   
            if(groundcheck==true)
            {
                Vector3 force = new Vector3(0, jumpForce, 0); // Force in the y direction
                rb.AddForce(force, ForceMode.Impulse);
            }
     
            
        }

    }
}
