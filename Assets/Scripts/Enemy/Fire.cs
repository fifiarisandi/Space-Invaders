using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the behaviour of the fire game object as the ProjectileBehaviour script 
public class Fire : MonoBehaviour
{
    public float speed;


    public float destroyAfter = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyFire", destroyAfter);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void DestroyFire()
    {
        
        Destroy(gameObject);
    }
}
