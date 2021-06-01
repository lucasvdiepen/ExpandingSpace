using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<AllItems> items = new List<AllItems>();

    public GameObject testItem;

    public enum AllItems
    {
        Diamond = 0,
        Emerald = 1
    }

    public void AddToInventory(GameObject item)
    {
        Item itemScript = item.GetComponent<Item>();
        items.Add(itemScript.item);
    }

    public void AddToInventory(AllItems item)
    {
        items.Add(item);
    }

    public bool HasItem(AllItems item)
    {
        foreach(AllItems currentItem in items)
        {
            if (currentItem == item) return true;
        }

        return false;
    }

    public int GetItemAmount(AllItems item)
    {
        int count = 0;
        foreach(AllItems currentItem in items)
        {
            if (currentItem == item) count++;
        }

        return count;
    }
}
