using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float offset = 8;
    private float zOffset = -10.0f;

    public float xMin, xMax, yMin, yMax;
    public float startingX, startingY;
    public float speed = 30.0f;

    [HideInInspector]
    public Transform ball;

    void Start()
    {
        resetCamera();
    }

    // Update is called once per frame
    void Update()
    {
        if(ball != null && !GameController.GameIsPaused) // ball is not null and game isnt paused
        {
            transform.position = new Vector3
            (
                    Mathf.Clamp(ball.position.x + offset, xMin, xMax),
                    Mathf.Clamp(ball.position.y, yMin, yMax),
                    zOffset
            );
        }
        else // game is paused
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            transform.position += (Vector3.up * vertical + Vector3.right * horizontal) * speed * Time.deltaTime;

            transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, xMin, xMax),
                Mathf.Clamp(transform.position.y, yMin, yMax),
                zOffset
            );
        }
    }

    public void resetCamera()
    {
        transform.position = new Vector3(startingX, startingY, zOffset);
    }
}
