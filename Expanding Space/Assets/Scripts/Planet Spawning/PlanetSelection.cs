using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetSelection : MonoBehaviour
{
    public enum Planets
    {
        Pluto,
        Mercury,
        Mars,
        Venus,
        Earth,
        Neptune,
        Uranus,
        Saturn,
        Jupiter
    }

    public static Planets nameOfPlanet;

    // if you call this function with a planet as parameter the travel game scene will load with the given planet
    static public void LoadTravelGame(Planets planet)
    {
        nameOfPlanet = planet;
        SceneManager.LoadScene("TravelGame");
    }
}
