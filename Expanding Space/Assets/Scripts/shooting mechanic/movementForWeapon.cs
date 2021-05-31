using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementForWeapon : MonoBehaviour
{
    public float offset;
    public bool movement;
    private float time;
    public float startTime;
    void Start()
    {
        time = 4;
        movement = true;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "MovableObject")
        {
            movement = false;
            time = startTime;

        }
    }
    public void Update()
    {
        time -= Time.deltaTime;
        if (movement)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        }
        if (time <= 0)
        {
            movement = true;
        }
    }
}
