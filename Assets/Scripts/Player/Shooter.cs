using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allows the player to shoot projectiles by instantiating them during run-time/gameplay
public class Shooter : MonoBehaviour
{
    // Public variables 
    public GameObject projectilePrefab;
    public float projectileRange;

    public float powerUpTime = 5f; 

    public AudioSource audio;
    public AudioClip collectSFX;

    // Private variables
    private bool powerUpCollected;

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
    // Checks if player collected the power up.
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Check the tag on the other game object. If it's the powerUp's tag,
        // set powerUpCollected boolean on true and destroy the powerUp 
        if (otherCollider.tag == "PowerUp")
        {
            // Sets the powerUpCollected bool to true, so that power is activated 
            powerUpCollected = true; 

            // Plays the power up collect sound. 
            audio.PlayOneShot(collectSFX);

            // StartCoroutine expects an IEnumerator and starts a coroutine (timed process). 
            // Starts TimerForPowerUp. 
            StartCoroutine(TimerForPowerUp());

            // Get the game object, as a whole, that's attached to the Collider2D component
            // Destroys the power up game object.
            Destroy(otherCollider.gameObject);
        }
    }

    // Fires shots of the player 
    private void Shoot()
    {
        // Create an instance of the GameObject referenced by the projectilePrefab variable
        // When the instance is created, position at the same location where the player currently is (by copying their transform.position),
        // and don't rotate the instance at all - let it keep its "identity" rotation

        // Calcutes the position of the left, the right and the middle projectile with small adjustments to fit the player's appearance. 
        Vector3 leftProjectile = new Vector3(gameObject.transform.position.x - projectileRange, gameObject.transform.position.y + 0.45f, 0);   
        Vector3 middleProjectile = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.75f, 0);
        Vector3 rightProjectile = new Vector3(gameObject.transform.position.x + projectileRange, gameObject.transform.position.y + 0.45f, 0);

        // If a power up is colleted the player shots three projectiles at once. 
        if (powerUpCollected)
        {
            Instantiate(projectilePrefab, leftProjectile, Quaternion.identity);
            Instantiate(projectilePrefab, middleProjectile, Quaternion.identity);
            Instantiate(projectilePrefab, rightProjectile, Quaternion.identity);

            // Plays shoting sound.
            audio.Play();
        } 
        else
        {
            // Without a power up the player shots one projectile. 
            Instantiate(projectilePrefab, middleProjectile, Quaternion.identity);

            // Plays shoting sound.
            audio.Play();
        }
    }

    //Sets timer for the PowerUp based on the powerUpTime Variable.
    //After the time is up, the powerUpCollected is reset to false. 
    private IEnumerator TimerForPowerUp()
    {
        // Everything after yield return has to wait for the supplied number of seconds. 
        yield return new WaitForSeconds(powerUpTime);

        // After the powerUpTime is up, the player return to having one projectile. 
        powerUpCollected = false;
    }
}
