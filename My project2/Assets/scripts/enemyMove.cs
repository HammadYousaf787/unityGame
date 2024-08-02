using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class enemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.0f;        // Speed of movement
    public float distance = 1.5f;     // Distance to move back and forth
    public float health = 10;
    private Vector3 startPosition;
    private AudioSource as1;
    private GameObject child;
    private audioWorking childScript;
    public Transform target;  // The target object to move towards

    void Start()
    {
        // Store the starting position
        startPosition = transform.position;
        as1 = GetComponent<AudioSource>();
        Transform child = transform.Find("audio");

        childScript = child.GetComponent<audioWorking>();
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            target = mainCamera.transform;
        }
        else
        {
            Debug.LogError("Main Camera not found in the scene.");
        }


    }
    public void HealthCut(float Arrowvelocity)
    {
        Debug.Log("health cut called");
        health = health - Arrowvelocity;
        Debug.Log("health is " + health);
        childScript.playDamageSound();
    }

    void Update()
    {
        if (target != null)
        {
            // Calculate the direction from the current position to the target's position
            Vector3 direction = (target.position - transform.position).normalized;

            // Move the object in the direction of the target
            // Keep the y position fixed at 0
            Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;
            newPosition.y = 0;  // Ensure the y position is set to 0
            transform.position = newPosition;
        }

    }
}
