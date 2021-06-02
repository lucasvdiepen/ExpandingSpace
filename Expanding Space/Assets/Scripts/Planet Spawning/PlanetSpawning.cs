using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawning : MonoBehaviour
{
    public GameObject defaultPlanet, pluto, mercury, mars, venus, earth, neptune, uranus, saturn, jupiter;
    void Update()
    {
        // this switch case checks the planet that needs to be loaded in
        switch (PlanetSelection.nameOfPlanet)
        {
            case PlanetSelection.Planets.Earth:
                earth.SetActive(true);
                break;

            case PlanetSelection.Planets.Pluto:
                pluto.SetActive(true);
                break;

            case PlanetSelection.Planets.Mercury:
                mercury.SetActive(true);
                break;

            case PlanetSelection.Planets.Venus:
                venus.SetActive(true);
                break;

            case PlanetSelection.Planets.Mars:
                mars.SetActive(true);
                break;

            case PlanetSelection.Planets.Jupiter:
                jupiter.SetActive(true);
                break;

            case PlanetSelection.Planets.Saturn:
                saturn.SetActive(true);
                break;

            case PlanetSelection.Planets.Uranus:
                uranus.SetActive(true);
                break;

            case PlanetSelection.Planets.Neptue:
                neptune.SetActive(true);
                break;

            default:
                
                defaultPlanet.SetActive(true);
                break;
        }
    }
}
