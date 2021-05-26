using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ShipHit : MonoBehaviour
{
     
    [SerializeField] ParticleSystem dieParticle = null;

   
    public GameObject mainCamera;
    public GameObject meteorite;

    public GameObject canvas;
    void OnTriggerEnter2D(Collider2D collision)
    {
        // compares if the ship hits a meteorite
        if (collision.CompareTag("Meteorite"))
        {
            // calls the ShipGetsHit function
            ShipGetsHit();
        }
        else if (collision.CompareTag("Planet"))
        {
            ShipEntersPlanet(PlanetSelection.nameOfPlanet);
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
        canvas.SetActive(true);

    }
    public void Retry()
    {
        // reloads this scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ShipEntersPlanet(string planet)
    {
        // sets the scripts to false
        mainCamera.GetComponent<CameraMovement>().enabled = false;
        meteorite.GetComponent<MeteoriteScript>().enabled = false;
        gameObject.GetComponent<MovementShip>().enabled = false;

        // load scene

        switch (planet)
        {
            case "Pluto":
                SceneManager.LoadScene("Pluto");
                break;

            case "Mercury":
                SceneManager.LoadScene("Mercury");
                break;

            case "Mars":
                SceneManager.LoadScene("Mars");
                break;

            case "Venus":
                SceneManager.LoadScene("Venus");
                break;

            case "Earth":
                SceneManager.LoadScene("Earth");
                break;

            case "Neptune":
                SceneManager.LoadScene("Neptune");
                break;

            case "Uranus":
                SceneManager.LoadScene("Uranus");
                break;

            case "Saturn":
                SceneManager.LoadScene("Saturn");
                break;

            case "Jupiter":
                SceneManager.LoadScene("Jupiter");
                break;

            default:
                Debug.LogError(planet + " is not a planet");
                break;
        }
    }
}
