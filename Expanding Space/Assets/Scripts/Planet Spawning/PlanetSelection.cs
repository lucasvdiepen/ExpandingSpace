using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetSelection : MonoBehaviour
{
    static public string nameOfPlanet;

    static public void LoadTravelGame(string planet)
    {
        nameOfPlanet = planet;
        SceneManager.LoadScene("TravelGame");
    }
}
