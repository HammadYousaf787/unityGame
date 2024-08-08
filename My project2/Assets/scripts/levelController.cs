using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControllerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool HealthPowerUp = false;
    public bool MusicPowerUp = false;
    public bool ReloadSpeedPowerUp = false;
    private camerarotation MainPlayerScript;
    public float delayBeforeEnabling = 10f; // Time in seconds before enabling the PowerUps GameObject
    private GameObject powerUpsObject;
    public float delayBeforeDancingEnds = 10f;
    public AudioSource powerUpAudioSrc;
    public AudioClip startAudio;
    public AudioClip selectedAudio;
    public AudioClip MusicAudio;



    void Start()
    {
        powerUpAudioSrc.clip = startAudio;
        powerUpAudioSrc.Play();
        powerUpAudioSrc.clip = selectedAudio;
        Debug.Log("heyyyy");
        MainPlayerScript = Camera.main.GetComponent<camerarotation>();
        if(MainPlayerScript == null)
        {
            Debug.Log("Camera script not found");
        }
        Transform childTransform = transform.Find("PowerUps 1");
        powerUpsObject = childTransform.gameObject;
        // Disable the GameObject at the start
        powerUpsObject.SetActive(false);

        // Start coroutine to enable it after delay
        StartCoroutine(EnablePowerUpsAfterDelay(delayBeforeEnabling));
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthPowerUp)
        {   

            Debug.Log("Health power up in levelController is true");
            MainPlayerScript.health += 50;
            powerUpsObject.SetActive(false);
            HealthPowerUp = false;
            powerUpAudioSrc.Play();
        }
        else if (MusicPowerUp)
        {
            Debug.Log("Music power up in levelController is true");
            MusicPowerUp = false;
            StartCoroutine(SetZombiesDancingCoroutine(true, delayBeforeDancingEnds));
            powerUpAudioSrc.Play();
            powerUpsObject.SetActive(false);
            powerUpAudioSrc.clip = MusicAudio;
            StartCoroutine(PlayAudioForDuration(15f));



        }
        else if (ReloadSpeedPowerUp)
        {   

            Debug.Log("reoladpower up in levelController is true");
            MainPlayerScript.arrowSpawnTimer = 0.5f;
            powerUpsObject.SetActive(false);
            ReloadSpeedPowerUp = false;
            powerUpAudioSrc.Play();

         
        }
    }
    private IEnumerator EnablePowerUpsAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Enable the PowerUps GameObject
        if (powerUpsObject != null)
        {
            powerUpsObject.SetActive(true);
        }
        else
        {
            Debug.LogError("PowerUps GameObject reference is lost.");
        }
    }
    IEnumerator SetZombiesDancingCoroutine(bool isDancing, float delay)
    {
        // Set the Dancing variable to true immediately
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("body_enemy");

        foreach (GameObject zombie in zombies)
        {
            enemyMovement zombiescript = zombie.GetComponent<enemyMovement>();
            if (zombiescript != null)
            {
                zombiescript.Dancing = isDancing;
            }
        }
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);
        MusicPowerUp = false;

        // Set the Dancing variable to false after the delay
        foreach (GameObject zombie in zombies)
        {
            enemyMovement zombiescript = zombie.GetComponent<enemyMovement>();
            if (zombiescript != null)
            {
                zombiescript.Dancing = false;
            }
        }

    }
    private IEnumerator PlayAudioForDuration(float duration)
    {
        powerUpAudioSrc.Play();
        yield return new WaitForSeconds(duration);
        powerUpAudioSrc.Stop();
    }

}
