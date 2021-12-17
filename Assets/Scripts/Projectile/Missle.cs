using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    // How fast will the project travel
    public float speed;

    // How much time, in seconds, before the projectile destroys itself (if it hits nothing and escapes the play area)
    public float destroyAfter = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyMissle", destroyAfter);
    }

    // Update is called once per frame
    void Update()
    {
        //Missles being shot going down
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Check the tag on the other game object. If it's the projectile's tag,
        //  destroy both this game object and the projectile
        if (otherCollider.tag == "Projectile" || otherCollider.tag == "Rocket")
        { 
            Destroy(gameObject);
            // Get the game object, as a whole, that's attached to the Collider2D component
            Destroy(otherCollider.gameObject);
        }

        
    }
    void DestroyMissle()
    {
        // Destroy the game object this script is on (the projectile game object)
        Destroy(gameObject);
    }
}
