using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the behaviour of each single Alien enemy
public class EnemyBehaviour : MonoBehaviour
{
    // Public variables 
    public GameObject powerUpPrefab;
    public Spawner spawnerReference; 

    public int enemyHealth;

    public AudioSource audio;
    public AudioClip hitSFX;

    // Private variables 
    private bool isAlive = true;


    // A function automatically triggerred when another game object with Collider2D component
    // Enters the Collider2D boundaries on this game object
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
		// Check the tag on the other game object. If it's the projectile's tag
		// and the enemy is alive destroy both this game object and the projectile
        if (otherCollider.tag == "Projectile" && isAlive)
        {
            // Reduces enemy's health after being hit
            enemyHealth -= 1;

            // Playes the hit sound after hitting an enemy. 
            audio.PlayOneShot(hitSFX);

            // Get the game object, as a whole, that's attached to the Collider2D component
            // Destroys players projectile, after hiting the enemy.
            Destroy(otherCollider.gameObject);

            // Checks if the enemy's health is reduced to zero. 
            if (enemyHealth <= 0)
            {
                // Pronounces enemy dead.
                isAlive = false; 

                // Random Generator ensures that a powerUp is dropped with a 20% chance.
                // If the random number is one, the enemy will drop a power up. 
                if (Random.Range(1, 6) == 1)
                {
                    // Create an instance of the GameObject referenced by the powerUpPrefab variable
                    // When the instance is created, position at the same location where the enemy currently is (by copying their transform.position),
                    Instantiate(powerUpPrefab, gameObject.transform.position, Quaternion.identity);
                }

                // Before the enemy is destroyed, the enemy Counter of the spawner is reduced. 
                // Calls the ReduceEnemies Method from Spawner on the spawnerReference.  
                spawnerReference.ReduceEnemies();

                // Starts TimerBeforeDestroy to allow the destroy sound to play.
                StartCoroutine(TimerBeforeDestroy());
            }  
        }
    }

    // Waits a second before destroying the enemy game oject to allow the sound to play. 
    private IEnumerator TimerBeforeDestroy()
    {
        // Makes the game object invisible by disabling the sprite renderer. 
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        // Everything after yield return has to wait for one seconds. 
        yield return new WaitForSeconds(1);

        // Destroys the enemy game object. 
        Destroy(gameObject);
    }
}
