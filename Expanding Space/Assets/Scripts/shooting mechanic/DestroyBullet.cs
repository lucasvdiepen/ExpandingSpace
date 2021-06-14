using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public GameObject destroyEffect;
    public GameObject bullet;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "MovableObject")
        {   
            FindObjectOfType<SoundManager>().PlayExplosionSound();
            Destroy(bullet);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }

        if (collision.collider.tag == "noneMovableObject")
        {   
            FindObjectOfType<SoundManager>().PlayExplosionSound();
            Destroy(bullet);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }
        if (collision.collider.tag == "Ground")
        {
            FindObjectOfType<SoundManager>().PlayExplosionSound();
            Destroy(bullet);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }
    }

}
