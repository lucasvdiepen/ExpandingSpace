using System;
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

    public string digPlaceName = "";

    public DigAction digAction;

    public Inventory.AllItems[] rewards;

    public Transform endTeleportPoint;

    //values voor in de inspector
    public int rgb1;
    public int rgb2;
    public int rgb3;

    private ParticleSystem dirt;

    [HideInInspector] public bool isDug = false;

    private void Start()
    {
        dirt = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ParticleSystem>();

        isDug = FindObjectOfType<SaveManager>().GetDug(digPlaceName);
    }

    public void Dig()
    {
        if(digAction == DigAction.Reward)
        {
            isDug = true;

            StartCoroutine(FindObjectOfType<Dig>().DigLoot(transform));

            //Give items to inventory here
            foreach (Inventory.AllItems reward in rewards)
            {
                FindObjectOfType<Inventory>().AddToInventory(reward);
            }

            FindObjectOfType<SaveManager>().SetDug(digPlaceName);
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
            Color newColor = new Color32(Convert.ToByte(rgb1), Convert.ToByte(rgb2), Convert.ToByte(rgb3), 255);
            main.startColor = newColor;
        }
    }
}
