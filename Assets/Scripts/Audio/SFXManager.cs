using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip shoot;
    public AudioClip explosion;
    public AudioClip mouseClick;

    public void PlaySFX(string clipToPlay)
    {
        if (clipToPlay == "Shoot") 
        {
            audioSource.clip = shoot;
            audioSource.Play();
        }

        if (clipToPlay == "Explosion")
        {
            audioSource.clip = explosion;
            audioSource.Play();
        }

        if (clipToPlay == "MouseClick")
        {
            audioSource.clip = mouseClick;
            audioSource.Play();
        }
    }
}
