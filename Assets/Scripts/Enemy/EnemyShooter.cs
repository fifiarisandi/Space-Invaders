using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public bool isBoss; 

    private bool isShooting; 

    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       if (isShooting == false)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Set shooting boolean to true, so that enemy is not shooting all the time
        isShooting = true; 

        //Depending on if the enemy is a boss or not, a random time is created after which the enemy shots.
        //StartCoroutine starts the timer that will trigger the shooting.  
        if (isBoss)
        {
            StartCoroutine(TimerForShooting(Random.Range(1, 3)));
        } 
        else 
        {
            StartCoroutine(TimerForShooting(Random.Range(1, 5)));
        }
        

    }

    //Sets a timer after which the enemy will shoot based on the pTime variable.  
    private IEnumerator TimerForShooting(int pTime)
    {
        yield return new WaitForSeconds(pTime);

        // Create an instance of the GameObject referenced by the projectilePrefab variable
        // When the instance is created, position at the same location where the enemy currently is (by copying their transform.position),
        // and don't rotate the instance at all - let it keep its "identity" rotation

        Vector3 leftProjectile = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y, 0);
        Vector3 rightProjectile = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y, 0);

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

        isShooting = false;
    }
}