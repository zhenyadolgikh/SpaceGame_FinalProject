using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip backgroundMusic;

    void Start()
    {
        audioSource.clip = backgroundMusic;

        audioSource.loop = true;

        PlayMusic();
    }

    public void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
   
}
