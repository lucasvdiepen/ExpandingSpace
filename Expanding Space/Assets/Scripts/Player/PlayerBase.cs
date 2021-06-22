using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private bool isNearBase = false;

    PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();

        playerControls.Base.EnterBase.performed += ctx => EnterBase();
    }

    private void OnEnable()
    {
        playerControls.Base.Enable();
    }

    private void OnDisable()
    {
        playerControls.Base.Disable();
    }

    private void EnterBase()
    {
        if(isNearBase)
        {
            Debug.Log("Show map");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Base") isNearBase = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Base") isNearBase = false;
    }
}
