using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;

    private Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.GameIsPaused)
        {
            transform.position = startPos.position;
        }
        else
        {
            if (transform.position == pos1.position)
            {
                nextPos = pos2.position;
            }
            if (transform.position == pos2.position)
            {
                nextPos = pos1.position;
            }
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        // set colliding object's parent as the platform so that it can move along with the platform
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("DynamicObject"))
        {
            other.gameObject.transform.parent = gameObject.transform;
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("DynamicObject"))
        {
            other.gameObject.transform.parent = null;
        }
    }
}
