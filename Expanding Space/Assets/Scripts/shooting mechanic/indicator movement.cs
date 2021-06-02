using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicatormovement : MonoBehaviour
{
    PlayerControls playerControls;
    public float movespeed = 600f;
    float movement = 0f;
    public GameObject weapon;
    private void Awake()
    {
        playerControls = new PlayerControls();

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

    void Update()
    {
        
    }
    public void Aiming(Vector2 position)
    {
        transform.RotateAround(Vector3.forward,  movement * Time.fixedDeltaTime * -movespeed);
    }
}
