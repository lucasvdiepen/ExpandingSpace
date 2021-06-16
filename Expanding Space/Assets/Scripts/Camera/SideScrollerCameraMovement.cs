using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerCameraMovement : MonoBehaviour
{
    private GameObject target;

    public float xMin = 0;
    public float xMax = 0;

    public float moveToPositionTime = 2f;

    private bool moveToPosition = false;
    private Vector3 movePosition;
    private Vector3 oldPosition;
    private float timeElapsed = 0;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(moveToPosition)
        {
            float x = Mathf.Clamp(Mathf.Lerp(oldPosition.x, movePosition.x, timeElapsed / moveToPositionTime), xMin, xMax);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);

            if (timeElapsed >= moveToPositionTime || (x >= xMax && movePosition.x >= oldPosition.x) || (x <= xMin && movePosition.x <= oldPosition.x))
            {
                moveToPosition = false;
                FindObjectOfType<PlayerRespawn>().RespawnPlayer();
            }

            timeElapsed += Time.deltaTime;
        }
        else
        {
            float x = Mathf.Clamp(target.transform.position.x, xMin, xMax);

            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
    }

    public void GoToPosition(Vector3 position)
    {
        movePosition = position;
        oldPosition = transform.position;
        timeElapsed = 0;
        moveToPosition = true;
    }
}
