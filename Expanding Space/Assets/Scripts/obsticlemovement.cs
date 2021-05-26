using UnityEngine;

public class obsticlemovement : MonoBehaviour
{
    public GameObject destroyEffect;
    public GameObject bullet;
    public GameObject movebleobject;
    public float offset;
    
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "MovebleObject")
        {

            Destroy(bullet);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }
    }
    
}
