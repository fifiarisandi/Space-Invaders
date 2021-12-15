using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the behaviour of each single Alien enemy
public class EnemyBehaviour : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public Spawner spawnerReference; 
    public int enemyHealth;

    private bool isAlive = true;

    public AudioSource audio;
    public AudioClip hitSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	// A function automatically triggerred when another game object with Collider2D component
	// Enters the Collider2D boundaries on this game object
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
		// Check the tag on the other game object. If it's the projectile's tag,
		//  destroy both this game object and the projectile
        if (otherCollider.tag == "Projectile" && isAlive)
        {
            //Enemy health is reduced after being hit
            enemyHealth -= 1;
            audio.PlayOneShot(hitSFX);

            // Get the game object, as a whole, that's attached to the Collider2D component
            Destroy(otherCollider.gameObject);

            if (enemyHealth <= 0)
            {
                isAlive = false; 

                // Random Generator ensures that a powerUp is dropped with a 20% chance. 
                if (Random.Range(1, 6) == 1)
                {
                    Instantiate(powerUpPrefab, gameObject.transform.position, Quaternion.identity);
                }

                //Before the enemy is destroyed, the enemy Counter of the spawner is reduced. 
                spawnerReference.ReduceEnemies();

                StartCoroutine(TimerBeforeDestroy());
            }  
        }
    }

    private IEnumerator TimerBeforeDestroy()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false; 
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

}
