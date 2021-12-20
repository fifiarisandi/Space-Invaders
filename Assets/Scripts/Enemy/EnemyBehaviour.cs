using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the behaviour of each single Alien enemy
public class EnemyBehaviour : MonoBehaviour
{
    public SFXManager sfxManager;
    public GameObject uiController;

    // Start is called before the first frame update
    void Start()
    {
        uiController = GameObject.Find("UIController");
    }

    // Update is called once per frame
    void Update()
    {
        uiController.GetComponent<UIController>().ClearTime();
    }

	// A function automatically triggerred when another game object with Collider2D component
	// Enters the Collider2D boundaries on this game object
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
		// Check the tag on the other game object. If it's the projectile's tag,
		//  destroy both this game object and the projectile
        if (otherCollider.tag == "Projectile")
        {

            //Destroy(gameObject);
            gameObject.SetActive(false);
			
			// Get the game object, as a whole, that's attached to the Collider2D component
            Destroy(otherCollider.gameObject);

            //Added explosion SFX
            sfxManager.PlaySFX("Explosion");

            //Counting number of defeated enemies
            uiController.GetComponent<UIController>().KillCount();

            // In case of moving to the next level
            //uiController.GetComponent<UIController>().SetForNextLevel();//



        }
    }

}
