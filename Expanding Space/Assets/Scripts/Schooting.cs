using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Schooting : MonoBehaviour
{
    public GameObject Enemy;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "bullet")
        {
            Destroy(Enemy);
        }
    }



}
