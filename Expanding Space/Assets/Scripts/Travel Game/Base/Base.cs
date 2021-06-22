using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Inventory;

public class Base : MonoBehaviour
{
    public AllItems[] requiredItems;

    public void Travel()
    {
        foreach(AllItems item in requiredItems)
        {
            if(!FindObjectOfType<Inventory>().HasItem(item)) return;
        }

        PlanetSelection.Planets currentPlanet = (PlanetSelection.Planets)Enum.Parse(typeof(PlanetSelection.Planets), SceneManager.GetActiveScene().name, true);
    }
}
