using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the behaviour of each single Alien enemy
public class EnemyBehaviour : MonoBehaviour
{
    //Enemy number of hits needed to be destroyed
    public int numberOfHits = 2;
    public int totalHits = 0;

    //Audio Variables
    public AudioSource audio;
    public AudioClip damageSFX;
    public AudioClip destroySFX;

    //Graphics
    public Sprite damageSprite;

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
        if (otherCollider.tag == "Projectile")
        {
            //Decrease the health of the enemy
            numberOfHits--;
            //Check if the enemy is not destoryed
            if(numberOfHits >= 1)
            {
                //Play the take damage SFX
                audio.PlayOneShot(damageSFX);
                //Change the image sprite of the enemy
                showSprite(damageSprite);
            }
            //If the enemy doesn't have any health left 
            if (numberOfHits == 0)
            {
                //Play the destruction SFX
                GameController.scoreValue++;
                audio.PlayOneShot(destroySFX);
                Destroy(gameObject);
               
            }

            // Get the game object, as a whole, that's attached to the Collider2D component
            Destroy(otherCollider.gameObject);
        }
        else if (otherCollider.tag == "Rocket")
        {
            numberOfHits = 0;
            //Play the destruction SFX
            GameController.scoreValue++;
            audio.PlayOneShot(destroySFX);
            Destroy(gameObject);

            // Get the game object, as a whole, that's attached to the Collider2D component
            Destroy(otherCollider.gameObject);
        }
    }

    //You pass the image sprite that you want to dispaly
    private void showSprite(Sprite imageSprite)
    {
        GetComponent<SpriteRenderer>().sprite = imageSprite;
    }

}
