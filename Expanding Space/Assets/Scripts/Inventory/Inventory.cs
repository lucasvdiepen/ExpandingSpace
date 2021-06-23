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
        Level1Emerald1,
        Level1Emerald2,
        Level2Emerald1,
        Level2Emerald2,
        Level3Emerald1,
        Level3Emerald2,
        Level4Emerald1,
        Level4Emerald2,
        Level5Emerald1,
        Level5Emerald2,
        Level6Emerald1,
        Level6Emerald2,
        Level7Emerald1,
        Level7Emerald2,
        Level8Emerald1,
        Level8Emerald2
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
