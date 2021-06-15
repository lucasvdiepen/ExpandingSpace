using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteScript : MonoBehaviour
{
    public float meteoriteMovementSpeed;

    public float timeBeforeDestroy;
    // Update is called once per frame
    void Update()
    {
        // meteorite goes to the left
        transform.position -= new Vector3(meteoriteMovementSpeed, 0, 0) * Time.deltaTime;

        // destroys the meteorite in 10 seconds
        Destroy(gameObject, timeBeforeDestroy);
    }
}
