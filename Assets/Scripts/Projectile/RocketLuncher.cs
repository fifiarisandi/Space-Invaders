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
        direction = (transform.localRotation * Vector2.up).normalized;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShootRocket()
    {

        //GameObject leftRoket = Instantiate(roketForwardPrefab, gameObject.transform.position + Vector3.left * 0.5f, Quaternion.Euler(0, 0, 45f));
       // GameObject righttRoket = Instantiate(roketForwardPrefab, gameObject.transform.position + Vector3.right * 0.5f, Quaternion.Euler(0, 0, -45f));
        GameObject roketInitiated = Instantiate(rocket.gameObject, gameObject.transform.position,gameObject.transform.rotation);
        Rocket goRoket = roketInitiated.GetComponent<Rocket>();
        goRoket.direction = this.direction;
        // leftRoket.transform.rotation = Quaternion.identity;
    }
}
