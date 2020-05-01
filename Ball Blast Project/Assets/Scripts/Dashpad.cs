using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashpad : MonoBehaviour
{
    public float boostValue = 1;
    public bool right = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if(right)
            other.GetComponent<Rigidbody2D>().AddForce(transform.right * boostValue, ForceMode2D.Impulse);
        else
            other.GetComponent<Rigidbody2D>().AddForce(-transform.right * boostValue, ForceMode2D.Impulse);
    }
}
