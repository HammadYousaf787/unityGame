using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headScript : MonoBehaviour
{
    // Start is called before the first frame update
    private enemyMove parentScript;

    private void Start()
    {
        // Get the ParentScript component from the parent object
        parentScript = GetComponentInParent<enemyMove>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        parentScript.HealthCut(10);
    }
}
