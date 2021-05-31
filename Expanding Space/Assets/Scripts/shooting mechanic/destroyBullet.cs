using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBullet : MonoBehaviour
{
    public GameObject destroyEffect;
    public GameObject bullet;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "MovableObject")
        {
            Destroy(bullet);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }

        if (collision.collider.tag == "noneMovableObject")
        {
            Destroy(bullet);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }
    }

}
