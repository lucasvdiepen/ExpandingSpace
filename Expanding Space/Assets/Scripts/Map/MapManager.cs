using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inventory;

public class MapManager : MonoBehaviour
{
    public UnityEngine.UI.Button[] planetButtons;

    public AllItems[] itemsLevel2, itemsLevel3, itemsLevel4, itemsLevel5, itemsLevel6, itemsLevel7, itemsLevel8, itemsLevel9;

    private void OnEnable()
    {
        for(int i = 0; i < planetButtons.Length; i++)
        {
            AddOnclickListener(i);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < planetButtons.Length; i++)
        {
            planetButtons[i].onClick.RemoveAllListeners();
        }
    }

    public void AddOnclickListener(int i)
    {
        planetButtons[i].onClick.AddListener(() => PlanetClicked(i + 1));
    }

    private void PlanetClicked(int planetId)
    {
        Debug.Log("Planet clicked " + planetId);
    }
}
