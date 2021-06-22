using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using static Inventory;

public class SaveManager : MonoBehaviour
{
    private string path = "";

    [System.Serializable]
    public class GameSaveData
    {
        public PlanetSelection.Planets planet;
        public List<AllItems> items;
        public List<string> dugPlaces;

        public GameSaveData()
        {
            items = new List<AllItems>();
            dugPlaces = new List<string>();
        }
    }

    private GameSaveData gameSaveData;

    private void Start()
    {
        path = Application.persistentDataPath + "/GameData.ex";

        //Get all save data
        LoadGameData();
    }

    private void LoadGameData()
    {
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            gameSaveData = formatter.Deserialize(stream) as GameSaveData;

            stream.Close();
        }
        else
        {
            gameSaveData = new GameSaveData();
        }
    }

    private void SaveGameData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, gameSaveData);
        stream.Close();
    }

    public List<AllItems> GetInventory()
    {
        return gameSaveData.items;
    }

    public void AddToInventory(AllItems item)
    {
        gameSaveData.items.Add(item);

        SaveGameData();
    }

    public PlanetSelection.Planets GetPlanet()
    {
        return gameSaveData.planet;
    }
    public void SetPlanet(PlanetSelection.Planets _planet)
    {
        gameSaveData.planet = _planet;

        SaveGameData();
    }

    public bool GetDug(string name)
    {
        if (gameSaveData.dugPlaces.Contains(name)) return true;
        return false;
    }

    public void SetDug(string name)
    {
        if(!string.IsNullOrEmpty(name))
        {
            if(!gameSaveData.dugPlaces.Contains(name))
            {
                gameSaveData.dugPlaces.Add(name);
            }
        }
    }
}
