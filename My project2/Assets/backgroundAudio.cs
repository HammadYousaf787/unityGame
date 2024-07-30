using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource bgAudio;
    public AudioClip bgAudioSource; // Initializes the array with a size of 4

    private void Start()
    {
        bgAudio.clip = bgAudioSource;
        bgAudio.Play();
    }


}
