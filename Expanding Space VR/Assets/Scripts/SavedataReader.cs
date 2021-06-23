using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SavedataReader : MonoBehaviour
{
    public GameObject[] Cubes;
    public string[] TextToShow;
    public TextMeshProUGUI[] Textboxes;

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

    public enum AllItems
    {
        World1Emerald1,
        World1Emerald2,
        World2Emerald1,
        World2Emerald2,
        World3Emerald1,
        World3Emerald2,
        World4Emerald1,
        World4Emerald2,
        World5Emerald1,
        World5Emerald2,
        World6Emerald1,
        World6Emerald2,
        World7Emerald1,
        World7Emerald2,
        World8Emerald1,
        World8Emerald2
    }


    private GameSaveData gameSaveData;
    private string path = "";
    [System.Serializable]
    public class GameSaveData
    {
        public Planets planet;
        public List<AllItems> items;
        public List<string> dugPlaces;

        public GameSaveData()
        {
            items = new List<AllItems>();
            dugPlaces = new List<string>();
        }

        public void SetLists()
        {
            if (items == null) items = new List<AllItems>();
            if (dugPlaces == null) dugPlaces = new List<string>();
        }

        public void Reset()
        {
            planet = (Planets)0;
            items = new List<AllItems>();
            dugPlaces = new List<string>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        path = (Application.persistentDataPath + "/../Expanding Space/GameData.ex");
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

    public void ShowStuff()
    {
        LoadGameData();
        //Is crystal in data?
    }
}
