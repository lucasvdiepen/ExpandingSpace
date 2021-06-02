using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<AllItems> items = new List<AllItems>();

    public static Inventory inventoryScript;

    private void Awake()
    {
        if (inventoryScript == null)
        {
            DontDestroyOnLoad(gameObject);
            inventoryScript = this;
        }
        else Destroy(gameObject);
    }

    public enum AllItems
    {
        World1Emerald1,
        World1Emerald2,
        World2Emerald1,
        World2Emerald2,
        World3Emerald1,
        Worl32Emerald2,
        World2Emerald1,
        World2Emerald2,
        World2Emerald1,
        World2Emerald2,
        World2Emerald1,
        World2Emerald2,
        World2Emerald1,
        World2Emerald2,
        World2Emerald1,
        World2Emerald2,
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
