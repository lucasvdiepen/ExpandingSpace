using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public GameObject destroyEffect;
    public GameObject bullet;

    public float explosionEffectTime = 3f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider)
        {   
            FindObjectOfType<SoundManager>().PlayExplosionSound();
            Destroy(bullet);
            GameObject newDestroyEffect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(newDestroyEffect, explosionEffectTime);
        }
    }

}
