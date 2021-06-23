using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<AllItems> items = new List<AllItems>();

    private void Start()
    {
        items = FindObjectOfType<SaveManager>().GetInventory();
    }

    public enum AllItems
    {
        World1Emerald1,
        World1Emerald2,
        World2Emerald1,
        World2Emerald2,
        World3Emerald1,
        World3Emerald2,
        World4Emerald1,
        World4Emerald2,
        World5Emerald1,
        World5Emerald2,
        World6Emerald1,
        World6Emerald2,
        World7Emerald1,
        World7Emerald2,
        World8Emerald1,
        World8Emerald2
    }

    public void AddToInventory(GameObject item)
    {
        Item itemScript = item.GetComponent<Item>();
        items.Add(itemScript.item);

        FindObjectOfType<SaveManager>().SetInventory(items);
    }

    public void AddToInventory(AllItems item)
    {
        items.Add(item);

        FindObjectOfType<SaveManager>().SetInventory(items);
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
