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

    [HideInInspector] public bool isDug = false;

    public void Dig()
    {
        if(digAction == DigAction.Reward)
        {
            isDug = true;

            StartCoroutine(FindObjectOfType<Dig>().DigLoot(transform));

            //Give items to inventory here
            foreach (GameObject reward in rewards)
            {
                FindObjectOfType<Inventory>().AddToInventory(reward);
            }
        }
        else if(digAction == DigAction.Teleport)
        {
            Debug.Log("Digging teleport");
            //FindObjectOfType<Dig>().DigTeleport(transform, endTeleportPoint);
            StartCoroutine(FindObjectOfType<Dig>().DigTeleport(transform, endTeleportPoint));
        }
    }
}
