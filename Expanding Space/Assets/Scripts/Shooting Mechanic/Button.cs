using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject buttons;
    public GameObject[] apearingBlocks;
    private float time;
    public float startTime;
    public bool minTime;
    public void Start()
    {
        time = 0.1f;
        ApearingBlocksSetActive(true);
        time = startTime;
    }
    void Update()
    {
        if (minTime)
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
            ApearingBlocksSetActive(false);
            transform.localScale = new Vector3(1, 0.25f, 1);
            transform.position = new Vector3(3.98f , -3.1f, 0);
            minTime = true;
        }
        if (collision.collider.tag == "Rock")
        {
            ApearingBlocksSetActive(false);
            transform.localScale = new Vector3(1, 0.25f, 1);
            transform.position = new Vector3(3.98f, -3.1f, 0);
            minTime = true;
        }
    }
    private void ApearingBlocksSetActive(bool active)
    {
        foreach (GameObject block in apearingBlocks)
        {
            block.SetActive(active);
        }
    }

}
