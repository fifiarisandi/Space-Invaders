using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allows the player to shoot projectiles by instantiating them during run-time/gameplay
public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileRange;

    private bool powerUpCollected;
    public float powerUpTime = 5; 

    public AudioSource audio;
    public AudioClip collectSFX;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
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

    // A function automatically triggerred when another game object with Collider2D component
    // Enters the Collider2D boundaries on this game object
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Check the tag on the other game object. If it's the powerUp's tag,
        //  set powerUpCollected boolean on true and destroy the powerUp 
        if (otherCollider.tag == "PowerUp")
        {
            powerUpCollected = true; 
            //audio.PlayOneShot(collectSFX);

            //Expects an IEnumerator and starts a coroutine (timed process). 
            StartCoroutine(TimerForPowerUp());

            // Get the game object, as a whole, that's attached to the Collider2D component
            Destroy(otherCollider.gameObject);
        }
    }

    private void Shoot()
    {
        // Create an instance of the GameObject referenced by the projectilePrefab variable
        // When the instance is created, position at the same location where the player currently is (by copying their transform.position),
        // and don't rotate the instance at all - let it keep its "identity" rotation

        //Calcute the position of the left and the right projectile
        Vector3 leftProjectile = new Vector3(gameObject.transform.position.x - projectileRange, gameObject.transform.position.y + 0.45f, 0);
        Vector3 middleProjectile = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.75f, 0);
        Vector3 rightProjectile = new Vector3(gameObject.transform.position.x + projectileRange, gameObject.transform.position.y + 0.45f, 0);

        if (powerUpCollected)
        {
            Instantiate(projectilePrefab, leftProjectile, Quaternion.identity);
            Instantiate(projectilePrefab, middleProjectile, Quaternion.identity);
            Instantiate(projectilePrefab, rightProjectile, Quaternion.identity);
            //audio.Play();
        } 
        else
        {
            Instantiate(projectilePrefab, gameObject.transform.position, Quaternion.identity);
            //audio.Play();
        }
        
    }

    //Sets timer for the PowerUp based on the powerUpTime Variable.
    //After the time is up, the powerUpCollected is reset to false. 
    private IEnumerator TimerForPowerUp()
    {
        yield return new WaitForSeconds(powerUpTime);
        powerUpCollected = false;
    }
}
