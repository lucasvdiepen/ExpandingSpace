using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory 
{
    //fuck dit
    public enum AllItems
    {
        Level1Emerald1,
        Level1Emerald2,
        Level2Emerald1,
        Level2Emerald2,
        Level3Emerald1,
        Level3Emerald2,
        Level4Emerald1,
        Level4Emerald2,
        Level5Emerald1,
        Level5Emerald2,
        Level6Emerald1,
        Level6Emerald2,
        Level7Emerald1,
        Level7Emerald2,
        Level8Emerald1,
        Level8Emerald2
    }
}

public class PlanetSelection
{
    //Godsamme zeg
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
}


public class SaveManager : MonoBehaviour
{
    public GameObject[] Cubes;
    public string[] TextToShow;
    public TextMeshProUGUI[] Textboxes;

    private string path = "";

    [System.Serializable]
    public class GameSaveData
    {
        public PlanetSelection.Planets planet;
        public List<Inventory.AllItems> items;
        public List<string> dugPlaces;

        public GameSaveData()
        {
            items = new List<Inventory.AllItems>();
            dugPlaces = new List<string>();
        }

        public void SetLists()
        {
            if (items == null) items = new List<Inventory.AllItems>();
            if (dugPlaces == null) dugPlaces = new List<string>();
        }

        public void Reset()
        {
            planet = (PlanetSelection.Planets)0;
            items = new List<Inventory.AllItems>();
            dugPlaces = new List<string>();
        }
    }

    private GameSaveData gameSaveData;

    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/../Expanding Space/GameData.ex";
        Cubes[15].SetActive(false);
        Textboxes[15].gameObject.SetActive(false);
        ShowStuff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadGameData()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            gameSaveData = formatter.Deserialize(stream) as GameSaveData;

            gameSaveData.SetLists();

            stream.Close();
        }
        else
        {
            gameSaveData = new GameSaveData();
        }
    }

    private bool HasItem(Inventory.AllItems item)
    {
        if (gameSaveData.items.Contains(item))
        {
            return true;
        }
        return false;
    }

    public void ShowStuff()
    {
        LoadGameData();
        //Is crystal in data?
        if (HasItem(Inventory.AllItems.Level1Emerald1))
        {
            Cubes[0].SetActive(true);
            Textboxes[0].gameObject.SetActive(true);
        }

        if (HasItem(Inventory.AllItems.Level1Emerald2))
        {
            Cubes[1].SetActive(true);
            Textboxes[1].gameObject.SetActive(true);
        }

        if (HasItem(Inventory.AllItems.Level2Emerald1))
        {
            Cubes[2].SetActive(true);
            Textboxes[2].gameObject.SetActive(true);
        }

        if (HasItem(Inventory.AllItems.Level2Emerald2))
        {
            Cubes[3].SetActive(true);
            Textboxes[3].gameObject.SetActive(true);
        }

        if (HasItem(Inventory.AllItems.Level3Emerald1))
        {
            Cubes[4].SetActive(true);
            Textboxes[4].gameObject.SetActive(true);
        }

        if (HasItem(Inventory.AllItems.Level3Emerald2))
        {
            Cubes[5].SetActive(true);
            Textboxes[5].gameObject.SetActive(true);
        }

        if (HasItem(Inventory.AllItems.Level4Emerald1))
        {
            Cubes[6].SetActive(true);
            Textboxes[6].gameObject.SetActive(true);
        }

        if (HasItem(Inventory.AllItems.Level4Emerald2))
        {
            Cubes[7].SetActive(true);
            Textboxes[7].gameObject.SetActive(true);
        }

        if (HasItem(Inventory.AllItems.Level5Emerald1))
        {
            Cubes[8].SetActive(true);
            Textboxes[8].gameObject.SetActive(true);
        }

        if (HasItem(Inventory.AllItems.Level5Emerald2))
        {
            Cubes[9].SetActive(true);
            Textboxes[9].gameObject.SetActive(true);
        }

        if (HasItem(Inventory.AllItems.Level6Emerald1))
        {
            Cubes[10].SetActive(true);
            Textboxes[10].gameObject.SetActive(true);
        }

        if (HasItem(Inventory.AllItems.Level6Emerald2))
        {
            Cubes[11].SetActive(true);
            Textboxes[11].gameObject.SetActive(true);
        }

        if (HasItem(Inventory.AllItems.Level7Emerald1))
        {
            Cubes[12].SetActive(true);
            Textboxes[12].gameObject.SetActive(true);
        }

        if (HasItem(Inventory.AllItems.Level7Emerald2))
        {
            Cubes[13].SetActive(true);
            Textboxes[13].gameObject.SetActive(true);
        }

        if (HasItem(Inventory.AllItems.Level8Emerald1))
        {
            Cubes[14].SetActive(true);
            Textboxes[14].gameObject.SetActive(true);
        }

        if (HasItem(Inventory.AllItems.Level8Emerald2))
        {
            Cubes[15].SetActive(true);
            Textboxes[15].gameObject.SetActive(true);
        }
    }
}
