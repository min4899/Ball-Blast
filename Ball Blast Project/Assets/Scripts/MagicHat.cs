using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHat : MonoBehaviour
{
    public GameObject exit;

    [HideInInspector]
    public bool overlap = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!overlap)
        {
            exit.GetComponent<MagicHat>().overlap = true; // disable collision temporarily for the other end to prevent object from teleporting infinitely.
            float speed = collision.GetComponent<Rigidbody2D>().velocity.magnitude;
            float angle = Vector2.SignedAngle(-transform.up, collision.GetComponent<Rigidbody2D>().velocity);
            Debug.Log(angle);
            collision.transform.position = exit.transform.position;
            Vector3 newVelocity = Quaternion.AngleAxis(angle, exit.transform.forward) * exit.transform.up * speed;

            collision.GetComponent<Rigidbody2D>().velocity = newVelocity;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        overlap = false;
    }
}
