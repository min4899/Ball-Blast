using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounceValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 reflection = Vector2.Reflect(other.relativeVelocity, transform.up);
        other.rigidbody.AddForce(reflection * bounceValue, ForceMode2D.Impulse);
    }
}
