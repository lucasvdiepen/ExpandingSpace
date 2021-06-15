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

    //values voor in de inspector
    public int rgb1;
    public int rgb2;
    public int rgb3;

    public ParticleSystem dirt;

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

            StartCoroutine(FindObjectOfType<Dig>().DigTeleport(transform, endTeleportPoint));
        }

        //particle system color
        var main = dirt.main;

        if (dirt)
        {
            main.startColor = new Color(rgb1, rgb2, rgb3, 255);
        }
    }
}
