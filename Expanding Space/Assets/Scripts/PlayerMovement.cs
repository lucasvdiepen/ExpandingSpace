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

    public float digDownPosition = -6.5f;

    private bool movingToPosition = false;
    private Vector3 digOldPosition = Vector3.zero;
    private Vector3 digPosition = Vector3.zero;
    private float digMoveTime = 0f;

    private float timeElapsed = 0;

    private bool freezeMovement = false;

    private bool isDigging = false;

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
        if(movingToPosition)
        {
            transform.position = Vector3.Lerp(digOldPosition, digPosition, timeElapsed / digMoveTime);

            if(timeElapsed >= digMoveTime)
            {
                movingToPosition = false;
                timeElapsed = 0;
            }

            timeElapsed += Time.deltaTime;
        }

        if(!freezeMovement)
        {
            Move(move.x);
        }
    }

    public IEnumerator DigLoot(Transform digPlacePosition)
    {
        if(!isDigging)
        {
            isDigging = true;

            freezeMovement = true;

            //Move to center
            MoveToPosition(digPlacePosition.position, 0.4f);

            //Move down animation here

            //Move down
            yield return new WaitUntil(() => !movingToPosition);

            MoveToPosition(new Vector3(digPlacePosition.position.x, digDownPosition, digPlacePosition.position.z), 1.5f);

            //Move up animation here

            //Move up
            yield return new WaitUntil(() => !movingToPosition);

            MoveToPosition(digPlacePosition.position, 1f);

            yield return new WaitUntil(() => !movingToPosition);

            freezeMovement = false;
            
            isDigging = false;
        }


    }

    public IEnumerator DigTeleport(Transform digPlacePosition, Transform digEndPlacePosition)
    {
        if(!isDigging)
        {
            isDigging = true;

            freezeMovement = true;

            //Move to center
            MoveToPosition(digPlacePosition.position, 0.4f);

            // Move down animation here

            //Move down
            yield return new WaitUntil(() => !movingToPosition);

            MoveToPosition(new Vector3(digPlacePosition.position.x, digDownPosition, digPlacePosition.position.z), 1f);

            //Move sideways
            yield return new WaitUntil(() => !movingToPosition);

            MoveToPosition(new Vector3(digEndPlacePosition.position.x, digDownPosition, digPlacePosition.position.z), 2f);

            //Move up animation here

            //Move up
            yield return new WaitUntil(() => !movingToPosition);

            MoveToPosition(new Vector3(digEndPlacePosition.position.x, digEndPlacePosition.position.y, digEndPlacePosition.position.z), 1f);

            yield return new WaitUntil(() => !movingToPosition);
            freezeMovement = false;

            isDigging = false;
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
            transform.Translate(direction * movementSpeed * Time.deltaTime, 0, 0, Space.World);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground") grounded = true;
    }
}
