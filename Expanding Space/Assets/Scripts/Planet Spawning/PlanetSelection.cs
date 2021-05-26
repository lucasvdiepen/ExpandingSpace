using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetSelection : MonoBehaviour
{
    static public string nameOfPlanet;

    // if you call this function with a planet as parameter the travel game scene will load with the given planet
    static public void LoadTravelGame(string planet)
    {
        nameOfPlanet = planet;
        SceneManager.LoadScene("TravelGame");
    }
}
