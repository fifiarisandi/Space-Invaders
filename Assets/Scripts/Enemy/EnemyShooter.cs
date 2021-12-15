using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    // Public variables
    public GameObject projectilePrefab;
    public AudioSource audio;

    public bool isBoss;

    // Private variables 
    private bool isShooting;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the enemy is shooting before shooting again.
        // Prevents rapid shooting from the enemy. 
       if (isShooting == false)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Set shooting boolean to true, when the shot shooting process starts.
        // While isShooting is true, the enemy can't shoot again. 
        isShooting = true;

        // Calls TimerForShootinh and gives the method a random time, after which the shot is fired.
        // Depending on if the enemy is a boss or not, the random time can be shorter. 
        // StartCoroutine is necessary for starting the TimerForShooting method.  
        if (isBoss)
        {
            StartCoroutine(TimerForShooting(Random.Range(1, 3)));       // Random timer of 1 or 2 seconds
        } 
        else 
        {
            StartCoroutine(TimerForShooting(Random.Range(1, 5)));       // Randim timer of 1,2,3 or 4 seconds
        }
    }

    // Sets a timer after which the enemy will shoot based on the pTime variable.  
    private IEnumerator TimerForShooting(int pTime)
    {
        // Everything after yield return has to wait for the supplied number of seconds.   
        yield return new WaitForSeconds(pTime);

        // Create an instance of the GameObject referenced by the projectilePrefab variable
        // When the instance is created, position at the same location where the enemy currently is (by copying their transform.position),
        // and don't rotate the instance at all - let it keep its "identity" rotation

        // Calculates the projectile position with small adjustedments of the x-position that allow two shots to be fired.  
        Vector3 leftProjectile = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y, 0);
        Vector3 rightProjectile = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y, 0);

        // If the enemy is a boss it can shot two projectiles at once. If not, it only gets one.
        // Plays enemy shoting sound after shoting the projectile.
        if (isBoss)
        {
            Instantiate(projectilePrefab, leftProjectile, Quaternion.identity);
            Instantiate(projectilePrefab, rightProjectile, Quaternion.identity);
            audio.Play();
        } 
        else
        {
            Instantiate(projectilePrefab, gameObject.transform.position, Quaternion.identity);
            audio.Play();
        }

        // After shooting the isShooting is set to false to allow the enemy to shoot again.  
        isShooting = false;
    }
}