﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounceValue = 5;

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
        other.rigidbody.AddForce(new Vector2(-other.relativeVelocity.x, other.relativeVelocity.y) * bounceValue, ForceMode2D.Impulse);
    }
}