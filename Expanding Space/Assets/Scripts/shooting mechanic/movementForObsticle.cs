using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementForObsticle : MonoBehaviour
{
    public float offset;
    public bool movement;
    private float time;
    public float startTime;
    public float speed;
    weaponControls weaponScript;
    public Rigidbody2D rigid;
    void Start()
    {
        time = 4;
        movement = false;
        weaponScript = GameObject.Find("weapon").GetComponent<weaponControls>();
        rigid.gravityScale = 1;
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
        if (movement){
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            rigid.gravityScale = 0;
        }
        if (time <= 0)
            {
            rigid.gravityScale = 1;
            movement = false;
            weaponScript.enabled = true;
        }
    }
}
