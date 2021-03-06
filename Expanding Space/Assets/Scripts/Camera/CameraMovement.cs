using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    public float movementSpeed = 0;
    public float topMovementSpeed = 0;
    public float movementSpeedIncreasement = 0.01f;
    void FixedUpdate()
    {

        transform.position += new Vector3(movementSpeed, 0, 0) * Time.deltaTime;

        // this if statement makes the camera slowely go to the top speed 
        if (movementSpeed <= topMovementSpeed)
        {
            movementSpeed += movementSpeedIncreasement;
        }
    }
}
