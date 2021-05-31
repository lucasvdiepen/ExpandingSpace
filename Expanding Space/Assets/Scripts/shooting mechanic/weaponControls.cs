using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponControls : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotpoint;
    private float TimeBtwShots;
    public float startTime;
    public float offset;

    PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();

        playerControls.Shooting.Shoot.performed += ctx => Shoot();
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

    public void Update()
    {
        TimeBtwShots -= Time.deltaTime;

    }

    public void Shoot()
    {
        if (TimeBtwShots <= 0)
        {
            Instantiate(projectile, shotpoint.position, transform.rotation);
            TimeBtwShots = startTime;
        }
    }

    public void Aiming(Vector2 position)
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(position) - transform.position;
                float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }
}
