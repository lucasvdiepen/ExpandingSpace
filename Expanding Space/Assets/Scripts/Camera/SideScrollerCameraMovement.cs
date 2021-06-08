using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerCameraMovement : MonoBehaviour
{
    private GameObject target;

    public float xMin = 0;
    public float xMax = 0;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float x = Mathf.Clamp(target.transform.position.x, xMin, xMax);

        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
