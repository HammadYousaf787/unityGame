using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioWorking : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource DamageSource;
    public AudioClip[] Grunts = new AudioClip[4]; // Initializes the array with a size of 4

    public void playDamageSound()
    {
        int randomIndex = Random.Range(0, Grunts.Length);
        DamageSource.clip = Grunts[randomIndex];
        DamageSource.Play();
    }

    
}
