using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 4;
    private Rigidbody2D rb;
    public float jumpPower = 6;
    [HideInInspector] public bool grounded = false;
    PlayerControls playerControls;
    Vector2 move;

    private bool freezeMovement = false;

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
        Move(move.x);
    }

    public void MoveToDigPlace(Transform digPlacePosition)
    {
        freezeMovement = true;

        // Move down animation

        //Move down

        //Move sideways

        //Move up animation

        //Move up
    }

    public void Move(float direction)
    {
        if (!freezeMovement)
        {
            transform.Translate(direction * movementSpeed * Time.deltaTime, 0, 0, Space.World);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground") grounded = true;
    }
}
