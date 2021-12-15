using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Public variables
    public GameObject losingScreen;

    // A function automatically triggerred when another game object with Collider2D component
    // Enters the Collider2D boundaries on this game object
    // Checks if the player gets hit by the enemy. 
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Check the tag on the other game object. If it's the enemy projectile's tag,
        //  destroy both this game object and the projectile
        if (otherCollider.tag == "EnemyProjectile")
        {
            // If the player is hit the losingScreen is set to active. 
            losingScreen.SetActive(true);

            // The player game object is destroyed. 
            Destroy(gameObject);

            // Get the game object, as a whole, that's attached to the Collider2D component
            Destroy(otherCollider.gameObject);
        }
    }

}
