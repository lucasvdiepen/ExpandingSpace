using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHit : MonoBehaviour
{
     
    [SerializeField] ParticleSystem dieParticle = null;

   
    public GameObject mainCamera;
    public GameObject meteorite;

    public GameObject text;
    void OnTriggerEnter2D(Collider2D collision)
    {
        // compares if the ship hits a meteorite
        if (collision.CompareTag("Meteorite"))
        {
            // calls the ShipGetsHit function
            ShipGetsHit();
        }    
    }

    void ShipGetsHit()
    {
        // sets the scripts to false
        mainCamera.GetComponent<CameraMovement>().enabled = false;
        meteorite.GetComponent<MeteoriteScript>().enabled = false;
        gameObject.GetComponent<MovementShip>().enabled = false;

        // sets the canSpawnMeteorite to false so no meteorite can spawn
        MeteoriteSpawner.canSpawnMeteorite = false;

        // plays the die particle
        dieParticle.Play();

        // shows the text
        text.SetActive(true);

    }
}
