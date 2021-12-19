using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allows the player to shoot projectiles by instantiating them during run-time/gameplay
public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public SFXManager sfxManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// Check if the player pressed the spacebar, mapped to the Jump input in project settings, to make them shoot
        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //Added Shoot SFX
        sfxManager.PlaySFX("Shoot");

        // Create an instance of the GameObject referenced by the projectilePrefab variable
        // When the instance is created, position at the same location where the player currently is (by copying their transform.position),
        // and don't rotate the instance at all - let it keep its "identity" rotation
        Instantiate(projectilePrefab, gameObject.transform.position, Quaternion.identity);
    }
}
