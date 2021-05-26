using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Schooting : MonoBehaviour
{
    public GameObject Cube;
    public GameObject Enemy;
    public ParticleSystem myParticlesystem;
    public GameObject weapon;
    public GameObject bullet;


    public float distance;
    public float range;

    public void Start()
    {
        range = 30;
    }

    private void OnMouseDown()
    {



        Destroy(Enemy);
        Instantiate(myParticlesystem, transform.position, transform.rotation);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("hallo");
        }
    }


}
