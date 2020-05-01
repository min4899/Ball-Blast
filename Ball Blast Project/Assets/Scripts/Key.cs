﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [Tooltip("Parent of group of lock blocks. Add more blocks under this parent if you need to.")] 
    public GameObject blocks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            blocks.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    */

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            blocks.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
