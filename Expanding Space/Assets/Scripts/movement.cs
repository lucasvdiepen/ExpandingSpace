using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    public float movementSpeed = 4;
    private Rigidbody2D rb;
    public float jumpPower = 6;
    [HideInInspector] public bool grounded = false;
    PlayerControls playerControls;
    Vector2 move;

    void Awake()
    {
        playerControls = new PlayerControls();

        playerControls.Gameplay.Jump.performed += ctx => Jump();
        playerControls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        playerControls.Gameplay.Move.canceled += ctx => move = Vector2.zero;
    }

    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerControls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        playerControls.Gameplay.Disable();
    }

    public void Jump()
    {
        if (grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpPower, 0);
            grounded = false;
        }
    }

    void Update()
    {
        Vector2 m = new Vector2(move.x * movementSpeed, rb.velocity.y) * Time.deltaTime;
        
        if (Keyboard.current.spaceKey.wasPressedThisFrame && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpPower, 0);
            grounded = false;
        }    

        if (Keyboard.current.aKey.isPressed && !Keyboard.current.dKey.isPressed)
        {
            Move(-1);
        }

        else if (Keyboard.current.dKey.isPressed && !Keyboard.current.aKey.isPressed)
        {
            Move(1);
        }

        else if (Keyboard.current.aKey.isPressed && Keyboard.current.dKey.isPressed)
        {
            return;
        }
        else Move(move.x);
    }

    public void Move(float direction)
    {
        transform.Translate(direction * movementSpeed * Time.deltaTime,0,0, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground") grounded = true;
    }
}