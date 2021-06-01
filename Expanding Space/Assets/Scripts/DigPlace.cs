using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigPlace : MonoBehaviour
{
    public GameObject[] rewards;
    [HideInInspector] public bool isDug = false;

    public void Dig()
    {
        isDug = true;

        //Give items to inventory here
        foreach(GameObject reward in rewards)
        {
            FindObjectOfType<Inventory>().AddToInventory(reward);
        }
    }
}
