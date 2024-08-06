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
    public int maxSpawnCount = 5; // Maximum number of targets to spawn

    private int spawnCount = 0; // Counter for number of targets spawned

    void Start()
    {
        // Start the spawning process
        InvokeRepeating("SpawnTarget", 0f, spawnInterval);
    }

    void SpawnTarget()
    {
        // Check if we've reached the maximum number of spawns
        if (spawnCount >= maxSpawnCount)
        {
            // Stop further spawning
            CancelInvoke("SpawnTarget");
            return;
        }

        // Calculate random position within the specified ranges
        float randomX = Random.Range(-xRange, xRange);
        float randomZ = Random.Range(-zRange, zRange);
        float fixedY = yPosition;

        // Calculate the spawn position
        Vector3 spawnPosition = new Vector3(randomX, fixedY, randomZ);

        // Instantiate the target at the calculated position
        GameObject spawnedObject = Instantiate(Target, spawnPosition, Quaternion.identity);

        // Calculate the direction to the camera and set the rotation
        Vector3 directionToCamera = transform.position - spawnPosition;
        spawnedObject.transform.rotation = Quaternion.LookRotation(directionToCamera);

        // Increment the spawn counter
        spawnCount++;
    }
}