using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    PlayerControls playerControls;

    public float offset = -90;

    private void Awake()
    {
        playerControls = new PlayerControls();

        //playerControls.Shooting.Shoot.performed += ctx => Shoot();
        playerControls.Shooting.Aiming.performed += ctx => Aiming(ctx.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        playerControls.Shooting.Enable();
    }

    private void OnDisable()
    {
        playerControls.Shooting.Disable();
    }

    public void Aiming(Vector2 position)
    {
        //Debug.Log(position);

        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(position);

        Debug.Log("Mouse world position: " + worldPosition);

        Vector2 difference = worldPosition - new Vector2(transform.position.x, transform.position.y);
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }
}
