using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip backgroundMusic;
    
    //mute music
    public Button muteButton;
    private bool isMuted = false;

    void Start()
    {
        audioSource.clip = backgroundMusic;

        audioSource.loop = true;

        PlayMusic();

        //BUTTON MUTE
        muteButton.onClick.AddListener(ToggleMute);
    }

    public void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
 
    public void ToggleMute()
    {
        isMuted = !isMuted;

        audioSource.mute = isMuted;

    }
   
}
