using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyScript : MonoBehaviour
{
    private enemyMove parentScript; // Ensure this matches the parent script's class name

    private void Start()
    {
        // Get the EnemyMove component from the parent object
        parentScript = GetComponentInParent<enemyMove>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherObject = collision.gameObject;
        arrowscript arrowScript = otherObject.GetComponent<arrowscript>();
        float velocityArrow = arrowScript.velocity;           
        parentScript.HealthCut(velocityArrow);
  
    }
}