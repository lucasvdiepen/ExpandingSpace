using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inventory;

public class MapManager : MonoBehaviour
{
    public UnityEngine.UI.Button[] planetButtons;

    public AllItems[] itemsLevel2, itemsLevel3, itemsLevel4, itemsLevel5, itemsLevel6, itemsLevel7, itemsLevel8, itemsLevel9;

    private List<AllItems[]> requiredLevelItems;

    private void Start()
    {
        requiredLevelItems = new List<AllItems[]>();
        requiredLevelItems.Add(itemsLevel2);
        requiredLevelItems.Add(itemsLevel3);
        requiredLevelItems.Add(itemsLevel4);
        requiredLevelItems.Add(itemsLevel5);
        requiredLevelItems.Add(itemsLevel6);
        requiredLevelItems.Add(itemsLevel7);
        requiredLevelItems.Add(itemsLevel8);
        requiredLevelItems.Add(itemsLevel9);
    }

    private void OnEnable()
    {
        for(int i = 0; i < planetButtons.Length; i++)
        {
            AddOnClickListener(i);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < planetButtons.Length; i++)
        {
            planetButtons[i].onClick.RemoveAllListeners();
        }
    }

    public void AddOnClickListener(int i)
    {
        planetButtons[i].onClick.AddListener(() => PlanetClicked(i));
    }

    private bool IsPlanetUnLocked(int id)
    {
        foreach(AllItems item in requiredLevelItems[id])
        {
            if (!FindObjectOfType<Inventory>().HasItem(item)) return false;
        }

        return true;
    }

    private void PlanetClicked(int planetId)
    {
        Debug.Log("Planet clicked " + planetId);

        if(planetId > 0)
        {
            //Check if player has all items
            if (!IsPlanetUnLocked(planetId - 1)) return;
        }

        PlanetSelection.LoadTravelGame((PlanetSelection.Planets)planetId);
    }
}
