using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    //Enemy Attack
    public float enemyshootingRate = 2f;
    public GameObject enemyMisslePrefab;

    public AudioSource audio;
    public AudioClip missleSFX;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemyAttack", enemyshootingRate, enemyshootingRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void EnemyAttack()
    {
        if (UnityEngine.Random.Range(1, 10) > 8)
        {
            Instantiate(enemyMisslePrefab, gameObject.transform.position, Quaternion.identity);
            audio.PlayOneShot(missleSFX);
        }
    }
}
