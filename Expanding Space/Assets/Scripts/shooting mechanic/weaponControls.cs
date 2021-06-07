using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControls : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotpoint;
    private float TimeBtwShots;
    public float startTime;
    public float offset;
    PlayerControls playerControls;
    public float LightTime;
    Collider2D playerCollider;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        playerCollider = playerObject.GetComponent<Collider2D>();
    }
    private void Awake()
    {
        playerControls = new PlayerControls();

        playerControls.Shooting.Shoot.performed += ctx => Shoot();
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
            GameObject newBullet = Instantiate(projectile, shotpoint.position, transform.rotation);
            Physics2D.IgnoreCollision(playerCollider, newBullet.GetComponent<Collider2D>());
            StartCoroutine(FindObjectOfType<AntenneLighting>().Shoot(LightTime));
            TimeBtwShots = startTime;
            
        }
    }

}
