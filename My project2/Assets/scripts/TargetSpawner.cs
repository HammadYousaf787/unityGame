using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Target;
    public float xRange = 10f; // Range for x position
    public float zRange = 10f; // Range for y position
    public float yPosition; // Fixed z position
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 cameraPosition = transform.position;

            float randomX = Random.Range(-xRange, xRange);
            float randomz = Random.Range(-zRange, zRange);
            float fixedy = yPosition;

            // Calculate the spawn position
            Vector3 spawnPosition = new Vector3(randomX, fixedy, randomz);

            // Instantiate the object at the calculated position
            GameObject spawnedObject = Instantiate(Target, spawnPosition, Quaternion.identity);

            Vector3 directionToCamera = transform.position - spawnPosition;
            spawnedObject.transform.rotation = Quaternion.LookRotation(directionToCamera);


        }
    }
}
