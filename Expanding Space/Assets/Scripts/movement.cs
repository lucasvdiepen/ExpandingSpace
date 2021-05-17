using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float movementSpeed = 4;
    private Rigidbody2D rb;
    public float jumpPower = 8;
    [HideInInspector] public bool grounded = false;

    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-movementSpeed, 0, 0) * Time.deltaTime;
        }
        else if (horizontalInput < 0 && !Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-movementSpeed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(movementSpeed, 0, 0) * Time.deltaTime;
        }
        else if (horizontalInput > 0 && !Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(movementSpeed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector3(0, jumpPower, 0);
            grounded = false;
        }
        else if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector3(0, jumpPower, 0);
            grounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground") grounded = true;
    }
}