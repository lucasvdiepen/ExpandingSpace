using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    void Start()
    {
        Invoke("Destroybullets", lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void Destroybullets()
    {   
        FindObjectOfType<SoundManager>().PlayExplosionSound();
        Destroy(gameObject);
    }
}

