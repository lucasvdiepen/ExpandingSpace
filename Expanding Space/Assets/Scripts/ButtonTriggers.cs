using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTriggers : MonoBehaviour
{
    public GameObject objectToRegister;
    public bool isCollected;

    // Start is called before the first frame update
    void Start()
    {
        isCollected = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == objectToRegister)
        {
            isCollected = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == objectToRegister)
        {
            isCollected = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
