using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Inventory.AllItems item;

    public bool isInWorld = false;

    private void Start()
    {
        if(isInWorld)
        {
            if (FindObjectOfType<Inventory>().HasItem(item)) Destroy(gameObject);
        }
    }
}
