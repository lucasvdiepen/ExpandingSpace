using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    public SoundManager soundManager;
    public static bool canSpawnMeteorite;
    
    public GameObject meteorite;

    public Vector3 meteoriteScale;
    
    float meteoriteSpawnPositionY;

    
    float meteoriteSpawnScale;

    
    float topSpawnPostionNumber = 5;
    float lowSpawnPostionNumber = -5;

    
    float topScaleNumber = 0.46f;
    float lowScaleNumber = 0.17f;

    
    float spawnPositionMeterorite;

    public float secondsToStopSpawning;

    public float secondsToNewMeteorite;

    void Start()
    {
        // calls the spawnmeteorite function in the beginning
        StartCoroutine(SpawnMeteorite());

        // sets the spawn meteorite 
        canSpawnMeteorite = true;

        // calls the spawnmeteorite function in the beginning
        StartCoroutine(StopSpawningMeteorite());
    }
    // Update is called once per frame
    void Update()
    {
        // randomizes the variables
        meteoriteSpawnPositionY = Random.Range(topSpawnPostionNumber, lowSpawnPostionNumber);
        meteoriteSpawnScale = Random.Range(topScaleNumber, lowScaleNumber);

        // calculates the position of where the meteorite will spawn
        spawnPositionMeterorite = GameObject.Find("BorderRight").transform.position.x + 10;

        meteoriteScale = new Vector3(meteoriteSpawnScale, meteoriteSpawnScale, meteoriteSpawnScale);
    }

    // this function spawns a meteorite
    IEnumerator SpawnMeteorite()
    {
        

        // waits for seconds
        yield return new WaitForSeconds(secondsToNewMeteorite);

        // sets the scale of the next meteorite
        meteorite.transform.localScale = meteoriteScale;

        // makes the meteorite
        Instantiate(meteorite, new Vector3(spawnPositionMeterorite, meteoriteSpawnPositionY, -0.43f), Quaternion.identity);

        // chack if it can spawn a meteorite
        if (canSpawnMeteorite)
        {
            //calls this function again so another meteorite will spawn
            StartCoroutine(SpawnMeteorite());
        }
        
    }
    IEnumerator StopSpawningMeteorite()
    {
        // waits for seconds
        yield return new WaitForSeconds(secondsToStopSpawning);
        
        // sets this bool to false so there wont spawn any meteorites anymore
        canSpawnMeteorite = false;
    }
}
