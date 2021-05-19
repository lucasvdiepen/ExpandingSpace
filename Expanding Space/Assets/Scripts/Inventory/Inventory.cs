using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<GameObject> items = new List<GameObject>();

    public enum AllItems
    {
        Diamond = 0,
        Emerald = 1
    }

    public void AddToInventory(GameObject item)
    {
        items.Add(item);
    }
}
