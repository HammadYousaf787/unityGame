using UnityEngine;
using System.Collections; // Make sure this namespace is included
using System;
using System.Collections.Generic;
using UnityEngine.Windows;


public class enemyMovement : MonoBehaviour
{
    public float speed = 1.0f;       // Speed of movement
    public float stopDistance = 1.5f; // Distance to stop from the camera
    private Rigidbody rb;            // Rigidbody component
    bool alive = true;
    private Animator animator1;
    private float Health = 10f;
    public Camera Cameraobj;
    private camerarotation cameraScript;
    bool attacking = false;

    void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody component missing from the object.");
        }
        animator1 = GetComponent<Animator>();
        animator1.SetBool("isMoving", true);
        Cameraobj = Camera.main;
        cameraScript = Cameraobj.GetComponent<camerarotation>();
    }

    private void OnCollisionEnter(Collision collision)
    {   
        if(collision.gameObject.CompareTag("arrow"))
        {
            GameObject collidedobj = collision.gameObject;
            arrowscript Arrowscript = collidedobj.GetComponent<arrowscript>();

            Debug.Log("collidedd obj script found");
            if (Arrowscript.isActive == true)
            {
                Debug.Log("health cut will be called");
                alive = false;
                animator1.SetBool("isDead", true);
                Arrowscript.isActive = false;
                rb.isKinematic = true;
                StartCoroutine(DestroyArrowAfterDelay(3f));

            }






        }

        
    }

    void FixedUpdate()
    {
        // Check if the Rigidbody and the camera are available

        if (alive==true)
        {
            bool isDancing = animator1.GetBool("isDancing");

            if (isDancing)
            {
                // Lock the Y position to keep the character on the ground
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }

            else if (rb != null && Camera.main != null)
            {
                // Get the camera's position
                Vector3 cameraPosition = Camera.main.transform.position;

                // Calculate the direction from the object's position to the camera
                Vector3 direction = (cameraPosition - transform.position).normalized;

                // Calculate the distance to the camera
                float distanceToCamera = Vector3.Distance(transform.position, cameraPosition);

                // Move the object towards the camera
                if (distanceToCamera > stopDistance)
                {
                    // Move the object in the direction of the camera
                    Vector3 moveDirection = direction * speed * Time.fixedDeltaTime;
                    rb.MovePosition(rb.position + moveDirection);

                    // Rotate the object to face the camera
                    Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                    rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, Time.fixedDeltaTime * speed));
                }
                else
                {
                    // Optionally, stop the object exactly `stopDistance` from the camera
                    Vector3 stopPosition = cameraPosition - direction * stopDistance;
                    stopPosition.y = transform.position.y; // Keep the object's y position the same
                    rb.position = stopPosition;

                    // Rotate the object to face the camera even when stopped
                    Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                    rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, Time.fixedDeltaTime * speed);
                    animator1.SetBool("isMoving", false);
                    animator1.SetBool("attackTrigger", true);
                    if(attacking == false)
                    {
                        StartCoroutine(HealthCutCoroutine());
                        
                    }

                }
            }


        }
    }
    private IEnumerator HealthCutCoroutine()
    {

        Debug.Log("in health cut co routine");
        attacking = true;
        cameraScript.HealthCut();

        yield return new WaitForSeconds(4f); // Wait for 4 seconds
        attacking = false;

    }
    private IEnumerator DestroyArrowAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Destroy the arrow GameObject
        Destroy(gameObject);
    }

}