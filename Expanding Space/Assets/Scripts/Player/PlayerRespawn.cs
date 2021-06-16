using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint;

    public float lowestY = 0;

    private Rigidbody2D rb;

    private bool isRespawning = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if(transform.position.y <= lowestY)
        {
            if(!isRespawning)
            {
                isRespawning = true;
                FindObjectOfType<SideScrollerCameraMovement>().GoToPosition(respawnPoint.position);
            }
        }
    }

    public void RespawnPlayer()
    {
        rb.velocity = Vector2.zero;
        transform.position = respawnPoint.position;
        isRespawning = false;
    }
}
