using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControls : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotpoint;
    private float timeBtwShots;
    public float startTime;
    public float offset;
    PlayerControls playerControls;
    public float lightTime;
    Collider2D playerCollider;
    Collider2D WallCollider;
    public GameObject Wall;

    private void Start()
    {
        GameObject BulletObject = GameObject.FindGameObjectWithTag("ShootThroughWall");
        WallCollider = BulletObject.GetComponent<Collider2D>();
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
        timeBtwShots -= Time.deltaTime;

    }
    
    public void Shoot()
    {
        if (timeBtwShots <= 0)
        {
            GameObject newBullet = Instantiate(projectile, shotpoint.position, transform.rotation);
            Physics2D.IgnoreCollision(playerCollider, newBullet.GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(WallCollider, newBullet.GetComponent<Collider2D>());
            FindObjectOfType<SoundManager>().PlayLaserSound();
            StartCoroutine(FindObjectOfType<AntenneLighting>().Shoot(lightTime));
            timeBtwShots = startTime;
        }
    }

}
