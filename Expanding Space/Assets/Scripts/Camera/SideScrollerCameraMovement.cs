using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerCameraMovement : MonoBehaviour
{
    private GameObject target;

    public bool freezeX = false;
    public float xMin = 0;
    public float xMax = 0;

    public bool freezeY = false;
    public float yMin = 0;
    public float yMax = 0;

    public float yOffset = 0;

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
            float newX = 0;
            float newY = 0;

            if (freezeX) newX = transform.position.x;
            else newX = Mathf.Clamp(Mathf.Lerp(oldPosition.x, movePosition.x, timeElapsed / moveToPositionTime), xMin, xMax);

            if (freezeY) newY = transform.position.y;
            else newY = Mathf.Clamp(Mathf.Lerp(oldPosition.y, movePosition.y, timeElapsed / moveToPositionTime), yMin, yMax);

            transform.position = new Vector3(newX, newY, transform.position.z);

            if (timeElapsed >= moveToPositionTime || (newX >= xMax && movePosition.x >= oldPosition.x) || (newX <= xMin && movePosition.x <= oldPosition.x))
            {
                moveToPosition = false;
                FindObjectOfType<PlayerRespawn>().RespawnPlayer();
            }

            timeElapsed += Time.deltaTime;
        }
        else
        {
            float newX = 0;
            float newY = 0;

            if (freezeX) newX = transform.position.x;
            else newX = Mathf.Clamp(target.transform.position.x, xMin, xMax);

            if (freezeY) newY = transform.position.y;
            else newY = Mathf.Clamp(target.transform.position.y + yOffset, yMin, yMax);

            transform.position = new Vector3(newX, newY, transform.position.z);
        }
    }

    public void GoToPosition(Vector3 position)
    {
        movePosition = position + new Vector3(0, yOffset, 0);
        oldPosition = transform.position;
        timeElapsed = 0;
        moveToPosition = true;
    }
}
