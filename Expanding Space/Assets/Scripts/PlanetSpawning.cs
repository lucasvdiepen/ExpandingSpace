using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawning : MonoBehaviour
{
    public GameObject defaultPlanet, pluto, mercury, mars, venus, earth, neptune, uranus, saturn, jupiter;
    void Update()
    {
        switch (PlanetSelection.nameOfPlanet)
        {
            case "Earth":
                earth.SetActive(true);
                break;

            case "Pluto":
                pluto.SetActive(true);
                break;

            case "Mercury":
                mercury.SetActive(true);
                break;

            case "Venus":
                venus.SetActive(true);
                break;

            case "Mars":
                mars.SetActive(true);
                break;

            case "Jupiter":
                jupiter.SetActive(true);
                break;

            case "Saturnus":
                saturn.SetActive(true);
                break;

            case "Uranus":
                uranus.SetActive(true);
                break;

            case "Nupetune":
                neptune.SetActive(true);
                break;

            default:
                Debug.LogError("You didn't choose a planet");
                defaultPlanet.SetActive(true);
                break;
        }
    }
}
