using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLuncher : MonoBehaviour
{
    public Rocket rocket;
    Vector2 direction;

    public AudioSource roketAudio;

    // Start is called before the first frame update
    void Start()
    {
        //initiliaze the direction to be the same as the launcher direction
        direction = (transform.localRotation * Vector2.up).normalized;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShootRocket()
    {

       //Initiate the rocket using the position of the rocket launcher and the orientation as well
        GameObject roketInitiated = Instantiate(rocket.gameObject, gameObject.transform.position,gameObject.transform.rotation);
        Rocket goRoket = roketInitiated.GetComponent<Rocket>();
        
        //To ensure the rocket will move in the upward direction with the rotation
        goRoket.direction = this.direction;
 
    }
}
