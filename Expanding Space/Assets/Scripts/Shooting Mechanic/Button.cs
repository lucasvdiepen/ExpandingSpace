using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject buttons;
    public GameObject apearingBlock1;
    public GameObject apearingBlock2;
    private float time;
    public float startTime;
    public bool minTime;
    public void Start()
    {
        time = 0.1f;
        apearingBlock1.SetActive(true);
        apearingBlock2.SetActive(true);
        time = startTime;
    }
    void Update()
    {
        if (minTime == true)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                Destroy(buttons);
            }
        }
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    { 

        if (collision.collider.tag == "MovableObject")
        {
            apearingBlock1.SetActive(false);
            apearingBlock2.SetActive(false);
            transform.localScale = new Vector3(1, 0.25f, 1);
            transform.position = new Vector3(3.98f , -3.1f, 0);
            minTime = true;
        }

    }

}
