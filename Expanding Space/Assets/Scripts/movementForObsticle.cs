using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementForObsticle : MonoBehaviour
{
    public float offset;
    public GameObject weapon;
    public bool movement;
    private float time;
    public float startTime;
    WeaponMovement weaponScript;

    void Start()
    {
        time = 4;
        movement = false;
       weaponScript = GameObject.Find("weapon").GetComponent<WeaponMovement>();
        
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "bullet")
        {
            movement = true;
            time = startTime;
            
            weaponScript.enabled=false;
            
        }
    }
    public void Update()
    {
        time -= Time.deltaTime;
        if (movement == true){
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


        }
        if (time <= 0)
            {
                movement = false;
            weaponScript.enabled = true;
        }
    }
}
