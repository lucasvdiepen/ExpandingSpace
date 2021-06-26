using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPick : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Emerald")
        {
            FindObjectOfType<Inventory>().AddToInventory(collision.gameObject);
            FindObjectOfType<SoundManager>().PlayGetItemSounds();
            Destroy(collision.gameObject);
        }
    }
}
