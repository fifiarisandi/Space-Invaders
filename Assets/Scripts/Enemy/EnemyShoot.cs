using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script allows enemies to shoot fire at the player as the Shooter script 
public class EnemyShoot : MonoBehaviour
{

    public GameObject firePrefab;

    //Variable for the player position 
    public GameObject checkPlayer;
    Vector2 position;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //Check player position and parent game object position, which are enemies, and shoot to the player
        position = new Vector2(checkPlayer.transform.position.x, gameObject.transform.position.y);
        Instantiate(firePrefab, position, Quaternion.identity);
   
    }
}
