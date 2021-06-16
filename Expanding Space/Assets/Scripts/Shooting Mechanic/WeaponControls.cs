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
    List<Collider2D> shootThroughWallColliders = new List<Collider2D>();
    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        playerCollider = playerObject.GetComponent<Collider2D>();
        GameObject[] shootThroughWall = GameObject.FindGameObjectsWithTag("ShootThroughWall");
        Debug.Log("shoot through wall " + shootThroughWall.Length);
        foreach (GameObject wall in shootThroughWall)
        {
            shootThroughWallColliders.Add(wall.GetComponent<Collider2D>());
        }
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
            foreach (Collider2D collider in shootThroughWallColliders)
            {
                Physics2D.IgnoreCollision(collider, newBullet.GetComponent<Collider2D>());
            }
            FindObjectOfType<SoundManager>().PlayLaserSound();
            StartCoroutine(FindObjectOfType<AntenneLighting>().Shoot(lightTime));
            timeBtwShots = startTime;

        }
    }

}
