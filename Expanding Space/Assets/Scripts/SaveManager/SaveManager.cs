using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using static Inventory;

public class SaveManager : MonoBehaviour
{
    private string path = "";

    public class GameSaveData
    {
        public PlanetSelection.Planets planet;
        /*public List<AllItems> items;
        public Dictionary<string, bool> digPlaces;

        public GameSaveData()
        {
            items = new List<AllItems>();
            digPlaces = new Dictionary<string, bool>();
        }*/
    }

    private GameSaveData gameSaveData;

    private void Start()
    {
        path = Application.persistentDataPath + "/GameData.ex";

        //Get all save data
        LoadGameData();

        //AddToInventory(AllItems.World1Emerald1);

        SetPlanet(PlanetSelection.Planets.Earth);

        SaveGameData();
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

    public PlanetSelection.Planets GetLevel()
    {
        return gameSaveData.planet;
    }

    public void AddToInventory(AllItems item)
    {
        gameSaveData.items.Add(item);
    }

    public void SetPlanet(PlanetSelection.Planets _planet)
    {
        gameSaveData.planet = _planet;
    }

    public void ChangeDigPlace(string name, bool isDug)
    {
        
    }
}
