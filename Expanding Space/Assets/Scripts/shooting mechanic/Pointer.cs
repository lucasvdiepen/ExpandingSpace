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
        playerControls.Shooting.AimingMouse.performed += ctx => AimingMouse(ctx.ReadValue<Vector2>());
        playerControls.Shooting.AimingController.performed += ctx => AimingController(ctx.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        playerControls.Shooting.Enable();
    }

    private void OnDisable()
    {
        playerControls.Shooting.Disable();
    }

    public void AimingMouse(Vector2 position) { Aiming(position, false); }

    public void AimingController(Vector2 position) { Aiming(position, true); }

    private void Aiming(Vector2 position, bool isController)
    {
        Vector2 newPosition;

        if (!isController)
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(position);
            newPosition = worldPosition - new Vector2(transform.position.x, transform.position.y);
        }
        else newPosition = position;

        float rotZ = Mathf.Atan2(newPosition.y, newPosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ + offset);
    }
}
