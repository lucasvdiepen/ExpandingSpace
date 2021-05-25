using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<GameObject> items = new List<GameObject>();

    public GameObject testItem;

    public enum AllItems
    {
        Diamond = 0,
        Emerald = 1
    }

    private AllItems GetItemType(GameObject item)
    {
        Item itemScript = item.GetComponent<Item>();
        return itemScript.item;
    }

    private AllItems[] GetAllItemTypes()
    {
        AllItems[] allItems = new AllItems[items.Count];

        for(int i = 0; i < items.Count; i++)
        {
            allItems[i] = GetItemType(items[i]);
        }

        return allItems;
    }

    public void AddToInventory(GameObject item)
    {
        items.Add(item);
    }

    public void RemoveItem(AllItems item)
    {

    }

    public bool HasItem(AllItems item)
    {
        foreach(AllItems currentItem in GetAllItemTypes())
        {
            if (currentItem == item) return true;
        }

        return false;
    }

    public int GetItemAmount(AllItems item)
    {
        int count = 0;
        foreach(AllItems currentItem in GetAllItemTypes())
        {
            if (currentItem == item) count++;
        }

        return count;
    }
}
