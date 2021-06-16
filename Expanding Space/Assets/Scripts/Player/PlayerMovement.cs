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

    public float groundDistance = 1f;

    public float digDownPosition = -6.5f;

    private bool movingToPosition = false;
    private Vector3 digOldPosition = Vector3.zero;
    private Vector3 digPosition = Vector3.zero;
    private float digMoveTime = 0f;

    private float timeElapsed = 0;

    private bool freezeMovement = false;

    private bool isDigging = false;

    public ParticleSystem dirt;

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

    public IEnumerator DigLoot(Transform digPlacePosition)
    {
        if(!isDigging)
        {
            dirt.Play();

            isDigging = true;

            freezeMovement = true;

            //Move to center
            MoveToPosition(digPlacePosition.position, 0.4f);

            //Move down animation here

            //Move down
            yield return new WaitUntil(() => !movingToPosition);

            MoveToPosition(new Vector3(digPlacePosition.position.x, digDownPosition, digPlacePosition.position.z), 1.5f);
            dirt.Stop();

            //Move up animation here

            //Move up
            yield return new WaitUntil(() => !movingToPosition);

            MoveToPosition(digPlacePosition.position, 1f);
            dirt.Play();

            yield return new WaitUntil(() => !movingToPosition);

            freezeMovement = false;
            
            isDigging = false;
            dirt.Stop();
        }


    }

    public IEnumerator DigTeleport(Transform digPlacePosition, Transform digEndPlacePosition)
    {
        if(!isDigging)
        {
            dirt.Play();

            isDigging = true;

            freezeMovement = true;

            //Move to center
            MoveToPosition(digPlacePosition.position, 0.4f);

            // Move down animation here

            //Move down
            yield return new WaitUntil(() => !movingToPosition);

            MoveToPosition(new Vector3(digPlacePosition.position.x, digDownPosition, digPlacePosition.position.z), 1f);

            dirt.Stop();

            //Move sideways
            yield return new WaitUntil(() => !movingToPosition);

            MoveToPosition(new Vector3(digEndPlacePosition.position.x, digDownPosition, digPlacePosition.position.z), 2f);

            //Move up animation here

            //Move up
            yield return new WaitUntil(() => !movingToPosition);

            dirt.Play();

            MoveToPosition(new Vector3(digEndPlacePosition.position.x, digEndPlacePosition.position.y, digEndPlacePosition.position.z), 1f);

            yield return new WaitUntil(() => !movingToPosition);
            freezeMovement = false;

            isDigging = false;
            dirt.Stop();
        }
    }

    public void MoveToPosition(Vector3 position, float moveTime)
    {
        timeElapsed = 0;
        movingToPosition = true;
        digPosition = position;
        digOldPosition = transform.position;
        digMoveTime = moveTime;
    }

    public void Move(float direction)
    {
        if (!freezeMovement)
        {
            rb.velocity = new Vector2(direction * movementSpeed * Time.fixedDeltaTime, rb.velocity.y);
        }
        else rb.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground") grounded = true;
    }
}
