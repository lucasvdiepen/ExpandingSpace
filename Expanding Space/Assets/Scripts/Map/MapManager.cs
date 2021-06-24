using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inventory;

public class MapManager : MonoBehaviour
{
    public UnityEngine.UI.Button exitButton;
    public UnityEngine.UI.Button[] planetButtons;

    public GameObject[] players;
    public GameObject[] locks;

    public AllItems[] itemsLevel2, itemsLevel3, itemsLevel4, itemsLevel5, itemsLevel6, itemsLevel7, itemsLevel8, itemsLevel9;

    private List<AllItems[]> requiredLevelItems;

    public GameObject mapCanvas;

    PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Map.MapExit.performed += ctx => CloseMap();
    }

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

    public void OpenMap()
    {
        if(!mapCanvas.activeSelf && !FindObjectOfType<GameManager>().isPaused)
        {
            FindObjectOfType<WeaponControls>().ToggleShooting(false);
            FindObjectOfType<PlayerMovement>().FreezeMovement(true);
            mapCanvas.SetActive(true);

            //Check all unlocked planets
            for(int i = 0; i < locks.Length; i++)
            {
                //Set all locks active
                locks[i].SetActive(true);

                if (IsPlanetUnLocked(i)) locks[i].SetActive(false);
            }

            //Set all players false
            for (int i = 0; i < players.Length; i++) players[i].SetActive(false);

            //Get current planet
            PlanetSelection.Planets currentPlanet = FindObjectOfType<SaveManager>().GetPlanet();
            //Set current planet player true
            players[(int)currentPlanet].SetActive(true);

            playerControls.Map.Enable();

            exitButton.onClick.AddListener(CloseMap);

            for (int i = 0; i < planetButtons.Length; i++)
            {
                AddOnClickListener(i);
            }
        }
    }

    public void CloseMap()
    {
        if(mapCanvas.activeSelf)
        {
            FindObjectOfType<WeaponControls>().ToggleShooting(true);
            FindObjectOfType<PlayerMovement>().FreezeMovement(false);
            mapCanvas.SetActive(false);

            playerControls.Map.Disable();

            exitButton.onClick.RemoveAllListeners();

            for (int i = 0; i < planetButtons.Length; i++)
            {
                planetButtons[i].onClick.RemoveAllListeners();
            }
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

        if ((PlanetSelection.Planets)planetId != FindObjectOfType<SaveManager>().GetPlanet())
        {
            if (planetId > 0)
            {
                //Check if player has all items
                if (!IsPlanetUnLocked(planetId - 1)) return;
            }

            CloseMap();

            PlanetSelection.LoadTravelGame((PlanetSelection.Planets)planetId);
        }
    }
}
