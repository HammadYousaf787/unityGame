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
    private GameObject child;
    private audioWorking childScript;
    void Start()
    {
        // Store the starting position
        startPosition = transform.position;
        as1 = GetComponent<AudioSource>();
        Transform child = transform.Find("audio");
        if (child == null)
        {
            Debug.Log("child is null");
        }
        else
        {
            Debug.Log("child is not null");

            childScript = child.GetComponent<audioWorking>();
        }
        if (childScript == null)
        {
            Debug.Log("child script is null");
        }
        else
        {
            Debug.Log("child script is not null");

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
        // Calculate the new position using a sine wave
        float offset = Mathf.Sin(Time.time * speed) * distance;
        transform.position = startPosition + new Vector3(offset, 0, 0);

    }

}
