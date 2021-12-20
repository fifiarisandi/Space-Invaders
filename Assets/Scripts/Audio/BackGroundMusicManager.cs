using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] backGroundMusics;

    public void BGMSelecter() 
    {
        int randomNum = Random.Range(0, 6);
        audioSource.clip = this.backGroundMusics[randomNum];
        audioSource.Play();
    }
}
