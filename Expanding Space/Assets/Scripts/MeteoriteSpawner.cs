using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    // Declares meteorite prefab
    public GameObject Meteorite;

    // this variable is for the Y position of the meteorite (will be changed constantly from the randomizer)
    float meteoriteSpawnPositionY;

    // this variable is for the scale of the meteorite (will be changed constantly from the randomizer)
    float meteoriteSpawnScale = 2.5f;

    // these variables are for the randomizer
    float topSpawnPostionNumber = 5;
    float lowSpawnPostionNumber = -5;

    // these variables are for the randomizer
    float topScaleNumber = 3;
    float lowScaleNumber = 2;

    float spawnPositionMeterorite;

    void Start()
    {
        StartCoroutine(SpawnMeteorite());  
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
        Meteorite.transform.localScale = new Vector3(meteoriteSpawnScale, meteoriteSpawnScale, meteoriteSpawnScale);
        yield return new WaitForSeconds(3);
        Instantiate(Meteorite, new Vector3(spawnPositionMeterorite, meteoriteSpawnPositionY, 0), Quaternion.identity);
        StartCoroutine(SpawnMeteorite());
    }
}
