using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // How fast will the project travel
    public float speed;
    public Vector2 direction = Vector2.up;

    // How much time, in seconds, before the projectile destroys itself (if it hits nothing and escapes the play area)
    public float destroyAfter = 4f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyRocket", destroyAfter);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void DestroyRocket()
    {
        // Destroy the game object this script is on (the Rocket game object)
        Destroy(gameObject);
    }
}
