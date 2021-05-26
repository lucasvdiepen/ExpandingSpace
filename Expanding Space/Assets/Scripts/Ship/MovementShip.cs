using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementShip : MonoBehaviour
{
    
    float startingPositionX = -6.85f;
    float startingPositionY = 0f;

   
    public float speed;

    
    bool ableToMoveUp = true;
    bool ableToMoveDown = true;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // if ship hits the top border ableToMoveUp becomes false
        if (collision.collider.CompareTag("BorderTop"))
        {
            ableToMoveUp = false;
        }

        // if ship hits the bottom border ableToMoveDown becomes false
        if (collision.collider.CompareTag("BorderDown"))
        {
            ableToMoveDown = false; 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // if ship hits the top border ableToMoveUp becomes true
        if (collision.collider.CompareTag("BorderTop"))
        {
            ableToMoveUp = true;
        }

        // if ship hits the bottom border ableToMoveDown becomes true
        if (collision.collider.CompareTag("BorderDown"))
        {
            ableToMoveDown = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // ship goes to starting position
        transform.position = new Vector3(startingPositionX, startingPositionY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        // if player presses W, ship goes up
        if (Input.GetKey(KeyCode.W) && ableToMoveUp)
        {
            // moves ship up
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }

        // if player presses S, ship goes down
        if (Input.GetKey(KeyCode.S) && ableToMoveDown)
        {
            // moves ship down
            transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
        }

        // if player presses A, ship goes to the left
        if (Input.GetKey(KeyCode.A))
        {
            // moves ship to the left
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        // if player presses D, ship goes to the right
        if (Input.GetKey(KeyCode.D))
        {
            // moves ship to the right
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
    }
}
