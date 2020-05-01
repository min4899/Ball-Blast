using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnProp : MonoBehaviour
{
    private float startingX;
    private float startingY;

    // Start is called before the first frame update
    void Start()
    {
        startingX = transform.position.x;
        startingY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.GameIsPaused)
        {
            transform.position = new Vector2(startingX, startingY);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            transform.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            //GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
        else
        {
            //GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
