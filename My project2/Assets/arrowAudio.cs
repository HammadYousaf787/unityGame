using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource ArrowSource;
    public AudioClip[] shootNoise = new AudioClip[2]; // Initializes the array with a size of 4

    public void playArrowSound(bool fast)
    {   
        if(!fast)
        {
        ArrowSource.clip = shootNoise[0];

        }
        else
        {

        ArrowSource.clip = shootNoise[1];
        }
        ArrowSource.Play();
    }


}
