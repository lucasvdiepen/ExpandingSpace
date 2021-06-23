using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inventory;

public class MapManager : MonoBehaviour
{
    public UnityEngine.UI.Button exitButton;
    public UnityEngine.UI.Button[] planetButtons;

    public AllItems[] itemsLevel2, itemsLevel3, itemsLevel4, itemsLevel5, itemsLevel6, itemsLevel7, itemsLevel8, itemsLevel9;

    private List<AllItems[]> requiredLevelItems;

    public GameObject mapCanvas;

    public static MapManager mapManager;

    PlayerControls playerControls;

    private void Awake()
    {
        if (mapManager == null)
        {
            DontDestroyOnLoad(gameObject);
            mapManager = this;
            playerControls = new PlayerControls();
            playerControls.Map.MapExit.performed += ctx => CloseMap();
        }
        else Destroy(gameObject);
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

    private void OnEnable()
    {
        playerControls.Map.Enable();

        exitButton.onClick.AddListener(CloseMap);

        for(int i = 0; i < planetButtons.Length; i++)
        {
            AddOnClickListener(i);
        }
    }

    private void OnDisable()
    {
        playerControls.Map.Disable();

        exitButton.onClick.RemoveAllListeners();

        for (int i = 0; i < planetButtons.Length; i++)
        {
            planetButtons[i].onClick.RemoveAllListeners();
        }
    }

    public void OpenMap()
    {
        FindObjectOfType<WeaponControls>().ToggleShooting(false);
        FindObjectOfType<PlayerMovement>().FreezeMovement(true);
        mapCanvas.SetActive(true);
    }

    public void CloseMap()
    {
        FindObjectOfType<WeaponControls>().ToggleShooting(true);
        FindObjectOfType<PlayerMovement>().FreezeMovement(false);
        mapCanvas.SetActive(false);
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
