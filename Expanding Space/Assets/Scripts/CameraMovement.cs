using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Setiing movementSpeed
    public float movementSpeed = 0;
    public float topMovementSpeed = 0;
    void FixedUpdate()
    {

        transform.position += new Vector3(movementSpeed, 0, 0) * Time.deltaTime;

        // this if statemen makes the camera slowely go to the speed 
        if (movementSpeed <= topMovementSpeed)
        {
            movementSpeed += 0.01f;
        }
    }
}
