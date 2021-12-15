using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script allows destroying the player and the enemies' fire as in EnemyBehaviour script
public class Playerdies : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip killPlayer;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D fireCollider)
    {
        
        if (fireCollider.tag == "Fire")
        {
            audio.PlayOneShot(killPlayer);
            Destroy(gameObject);
            gameOverPanel.SetActive(true);
    
            Destroy(fireCollider.gameObject);
        }
    }
}
