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

        public void SetLists()
        {
            if (items == null) items = new List<AllItems>();
            if (dugPlaces == null) dugPlaces = new List<string>();
        }

        public void Reset()
        {
            planet = (PlanetSelection.Planets)0;
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

            gameSaveData.SetLists();

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

    public void RemoveAllData()
    {
        gameSaveData = new GameSaveData();

        SaveGameData();
    }

    public List<AllItems> GetInventory()
    {
        return gameSaveData.items;
    }

    public void SetInventory(List<AllItems> items)
    {
        gameSaveData.items = items;

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
        if(!string.IsNullOrEmpty(name))
        {
            if (gameSaveData.dugPlaces.Contains(name)) return true;
        }
        return false;
    }

    public void SetDug(string name)
    {
        if(!string.IsNullOrEmpty(name))
        {
            if(!gameSaveData.dugPlaces.Contains(name))
            {
                gameSaveData.dugPlaces.Add(name);

                SaveGameData();
            }
        }
    }
}
