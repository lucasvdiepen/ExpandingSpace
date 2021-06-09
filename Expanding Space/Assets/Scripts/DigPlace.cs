using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigPlace : MonoBehaviour
{
    public enum DigAction
    {
        Reward,
        Teleport
    }

    public DigAction digAction;

    public GameObject[] rewards;

    public Transform endTeleportPoint;

    //string voor in de inspector
    public string digPlaceColor;

    [HideInInspector] public bool isDug = false;

    public void Dig()
    {
        if(digAction == DigAction.Reward)
        {
            isDug = true;

            StartCoroutine(FindObjectOfType<PlayerMovement>().DigLoot(transform));
            //Give items to inventory here
            foreach (GameObject reward in rewards)
            {
                FindObjectOfType<Inventory>().AddToInventory(reward);
            }
        }
        else if(digAction == DigAction.Teleport)
        {
            FindObjectOfType<PlayerMovement>().DigTeleport(transform, endTeleportPoint);
            StartCoroutine(FindObjectOfType<PlayerMovement>().DigTeleport(transform, endTeleportPoint));
        }
    }
}
