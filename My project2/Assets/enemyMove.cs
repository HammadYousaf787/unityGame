using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.0f;        // Speed of movement
    public float distance = 1.5f;     // Distance to move back and forth
    public float health = 10;
    private Vector3 startPosition;
    private AudioSource as1; 

    void Start()
    {
        // Store the starting position
        startPosition = transform.position;
        as1 = GetComponent<AudioSource>();

    }
    public void HealthCut(float Arrowvelocity)
    {
        Debug.Log("health cut called");
        health -= Arrowvelocity;
        Debug.Log("healt is "+ health);
    }

    void Update()
    {
        // Calculate the new position using a sine wave
        float offset = Mathf.Sin(Time.time * speed) * distance;
        transform.position = startPosition + new Vector3(offset, 0, 0);
        
    }
    
}
