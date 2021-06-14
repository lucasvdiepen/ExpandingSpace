using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementForObsticle : MonoBehaviour
{
    public float offset;
    public bool movement;
    private float time;
    public float startTime;
    public float speed;
    WeaponControls weaponScript;
    Pointer pointerScript;
    public Rigidbody2D rigid;
    PlayerControls playerControls;
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

    void Start()
    {
        time = 4;
        movement = false;
        weaponScript = GameObject.Find("Weapon").GetComponent<WeaponControls>();
        pointerScript = GameObject.Find("PointerHolder").GetComponent<Pointer>();
        
        rigid.gravityScale = 1;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "bullet")
        {
            movement = true;
            time = startTime;
            weaponScript.enabled=false;
            pointerScript.enabled = false;
        }
    }
    private void Aiming(Vector2 position, bool isController)
    {
        Vector2 newPosition;
        if (movement)
        {
            if (!isController)
                    {
                        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(position);
                        newPosition = worldPosition - new Vector2(transform.position.x, transform.position.y);
            }
                    
                    else newPosition = position;
            float rotZ = Mathf.Atan2(newPosition.y, newPosition.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0, 0, rotZ + offset);
            rigid.gravityScale = 0;
            if (time <= 0)
            {
                rigid.gravityScale = 1;
                movement = false;
                weaponScript.enabled = true;
                pointerScript.enabled = true;
            }
        }
        
    }
    public void Update()
    {
        time -= Time.deltaTime;
        if (movement)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
}
