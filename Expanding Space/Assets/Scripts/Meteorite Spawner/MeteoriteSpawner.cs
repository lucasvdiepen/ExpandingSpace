using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    public static bool canSpawnMeteorite;
    
    public GameObject Meteorite;

    
    float meteoriteSpawnPositionY;

    
    float meteoriteSpawnScale = 2.5f;

    
    float topSpawnPostionNumber = 5;
    float lowSpawnPostionNumber = -5;

    
    float topScaleNumber = 3;
    float lowScaleNumber = 2;

    
    float spawnPositionMeterorite;

    void Start()
    {
        // calls the spawnmeteorite function in the beginning
        StartCoroutine(SpawnMeteorite());

        // sets the spawn meteorite 
        canSpawnMeteorite = true;
    }
    // Update is called once per frame
    void Update()
    {
        // randomizes the variables
        meteoriteSpawnPositionY = Random.Range(topSpawnPostionNumber, lowSpawnPostionNumber);
        meteoriteSpawnScale = Random.Range(topScaleNumber, lowScaleNumber);

        // calculates the position of where the meteorite will spawn
        spawnPositionMeterorite = GameObject.Find("BorderRight").transform.position.x + 10;
    }

    // this function spawns a meteorite
    IEnumerator SpawnMeteorite()
    {
        // sets the scale of the next meteorite
        Meteorite.transform.localScale = new Vector3(meteoriteSpawnScale, meteoriteSpawnScale, meteoriteSpawnScale);

        // waits for seconds
        yield return new WaitForSeconds(3);

        // makes the meteorite
        Instantiate(Meteorite, new Vector3(spawnPositionMeterorite, meteoriteSpawnPositionY, 0), Quaternion.identity);

        // chack if it can spwn a meteorite
        if (canSpawnMeteorite)
        {
            //calls this function again so another meteorite will spawn
            StartCoroutine(SpawnMeteorite());
        }
        
    }
}
