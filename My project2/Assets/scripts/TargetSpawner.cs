using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject Target;
    public float xRange = 10f; // Range for x position
    public float zRange = 10f; // Range for z position
    public float yPosition; // Fixed y position
    public float spawnInterval = 5f; // Interval in seconds for spawning

    void Start()
    {
        InvokeRepeating("SpawnTarget", 0f, spawnInterval);
    }

    void SpawnTarget()
    {
        float randomX = Random.Range(-xRange, xRange);
        float randomZ = Random.Range(-zRange, zRange);
        float fixedY = yPosition;

        // Calculate the spawn position
        Vector3 spawnPosition = new Vector3(randomX, fixedY, randomZ);

        // Instantiate the object at the calculated position
        GameObject spawnedObject = Instantiate(Target, spawnPosition, Quaternion.identity);

        Vector3 directionToCamera = transform.position - spawnPosition;
        spawnedObject.transform.rotation = Quaternion.LookRotation(directionToCamera);
    }
}