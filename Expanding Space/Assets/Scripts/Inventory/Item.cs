using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Inventory.AllItems item;

    private void Start()
    {
        if (FindObjectOfType<Inventory>().HasItem(item)) Destroy(gameObject);
    }
}
