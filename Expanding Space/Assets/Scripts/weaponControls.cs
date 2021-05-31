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

    public void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }

    public void Update()
    {
        if (TimeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, shotpoint.position, transform.rotation);
                TimeBtwShots = startTime;
            }
        }
        else
        {
            TimeBtwShots -= Time.deltaTime;
        }
    }
}
