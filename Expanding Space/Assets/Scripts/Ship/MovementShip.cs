using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementShip : MonoBehaviour
{
    private Vector2 move;
    float startingPositionX = -6.85f;
    float startingPositionY = 0f;

   
    public float speed; 

    PlayerControls playerControls;
    void Awake()
    {
        playerControls = new PlayerControls();
        
        playerControls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();

        playerControls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

    }

    void OnEnable()
    {
        playerControls.Gameplay.Enable();
        
    }

    void OnDisable()
    {
        playerControls.Gameplay.Disable();
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
        Move(move);
    }

    public void Move(Vector2 movePosition)
    {
        transform.position += new Vector3(movePosition.x, movePosition.y, 0) * speed * Time.deltaTime;
    }
}
