using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Collider2D projectileCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D giftCollider)
    {
        if (giftCollider.tag == "Gift" && projectileCollider.tag == "Projectile") 
        {
            projectileCollider.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1f, 1f);
            
            Destroy(giftCollider.gameObject);
        }
    }
}
