using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetSpawner : MonoBehaviour
{
    public GameObject Target;
    public float xRange = 10f; // Range for x position
    public float zRange = 10f; // Range for z position
    public float yPosition; // Fixed y position
    public float spawnInterval = 5f; // Interval in seconds for spawning
    public int maxSpawnCount = 5; // Maximum number of targets to spawn
    public string nextLevelName; // Name of the next level to load

    private int spawnCount = 0; // Counter for number of targets spawned
    private float elapsedTime = 0f; // Timer to track elapsed time

    void Start()
    {
        // Start the spawning process
        InvokeRepeating("SpawnTarget", 0f, spawnInterval);
    }

    void Update()
    {
        // Update the elapsed time
        elapsedTime += Time.deltaTime;

        // Check if the conditions are met
<<<<<<< HEAD
        if (spawnCount >= maxSpawnCount)
        {
            // Load the next level
            GameObject zombie = GameObject.FindGameObjectWithTag("body_enemy");
            if(zombie == null)
            {
                LoadNextLevel();

            }
=======
        if (spawnCount >= maxSpawnCount && elapsedTime > 30f)
        {
            // Load the next level
            LoadNextLevel();
>>>>>>> 67361f41b5ab93257b692c7cb29dfd0d530de5df
        }
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

    void LoadNextLevel()
    {
        // Load the next level
        SceneManager.LoadScene(nextLevelName);
    }
}
