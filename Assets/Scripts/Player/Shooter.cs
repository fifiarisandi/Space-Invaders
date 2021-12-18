using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script allows the player to shoot projectiles by instantiating them during run-time/gameplay
public class Shooter : MonoBehaviour
{
    RocketLuncher[] lunchers;
    
    public GameObject projectilePrefab;
    public Slider roketWaitTimeSlider;

    public AudioSource audio;
    public AudioClip bulletSFX;
    public AudioClip rocketSFX;

    public bool rocketFired;
    public float rocketRelaunchTimer;
    float launchTime;

    public int numberOfBullets;

    // Start is called before the first frame update
    void Start()
    {
        //Get all children function with (s) !!!!
        lunchers = transform.GetComponentsInChildren<RocketLuncher>();
        
        rocketFired = false;

        roketWaitTimeSlider.maxValue = rocketRelaunchTimer;
        roketWaitTimeSlider.value = rocketRelaunchTimer;   
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player pressed the spacebar, mapped to the Jump input in project settings, to make them shoot
        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }

        
        // Check if the player pressed the 'Left Ctrl' key, mapped to the Jump input in project settings, to make them shoot
        if (Input.GetButtonDown("Fire1") && !rocketFired)
        {
            //Indicate the rockets have been fired
            rocketFired = true;
            launchTime = Time.time;
            roketWaitTimeSlider.value = 0;
            //for each rocket luncher shoot one missle
            foreach (var luncher in lunchers)
            {
                luncher.ShootRocket();
            }
            //Plays the rocket lunching Sound Effect
            audio.PlayOneShot(rocketSFX);
        }

        //If rockets fired start counting timer until next relanch
        if (rocketFired)
        {
            if (roketWaitTimeSlider.value < rocketRelaunchTimer)
            {
                //Connecting the timer count with the rocket slider UI
                roketWaitTimeSlider.value = Time.time - launchTime;

            }
            else
            {   //To reactivate the firing mechanisim
                rocketFired = false;
            }
        }
    }

   

    void Shoot()
    {
		// Create an instance of the GameObject referenced by the projectilePrefab variable
		// When the instance is created, position at the same location where the player currently is (by copying their transform.position),
		// and don't rotate the instance at all - let it keep its "identity" rotation
        Instantiate(projectilePrefab, gameObject.transform.position, Quaternion.identity);
        audio.PlayOneShot(bulletSFX);
        //bulletAudio.Play();  
    }
}
