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

    public float groundDistance = 1f;

    public float digDownPosition = -6.5f;

    private bool movingToPosition = false;
    private Vector3 digOldPosition = Vector3.zero;
    private Vector3 digPosition = Vector3.zero;
    private float digMoveTime = 0f;

    private float timeElapsed = 0;

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

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundDistance);
        if (hit.transform.tag == "Ground") return true;

        return false;
    }

    public void Jump()
    {
        //Check if grounded

        if (grounded)
        {
            FindObjectOfType<SoundManager>().PlayJumpSound();
            rb.velocity = new Vector3(rb.velocity.x, jumpPower, 0);
            grounded = false;            
        }
    }

    void Update()
    {
        if (movingToPosition)
        {
            transform.position = Vector3.Lerp(digOldPosition, digPosition, timeElapsed / digMoveTime);

            if (timeElapsed >= digMoveTime)
            {
                movingToPosition = false;
                timeElapsed = 0;
            }

            timeElapsed += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Move(move.x);
    }

    public void Move(float direction)
    {
        if (!freezeMovement)
        {

            if (direction < 0)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, 180f, transform.rotation.z);
            }
            else if (direction > 0)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.z);
            }

            rb.velocity = new Vector2(direction * movementSpeed * Time.fixedDeltaTime, rb.velocity.y);
        }
        else rb.velocity = Vector2.zero;
    }

    public void FreezeMovement(bool freeze)
    {
        if(freeze)
        {
            freezeMovement = true;
            rb.gravityScale = 0;
        }
        else
        {
            freezeMovement = false;
            rb.gravityScale = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground") grounded = true;
    }
}
