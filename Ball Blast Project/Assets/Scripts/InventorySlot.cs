using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public GameObject item;
    public GameObject parentObject; // which parent to spawn under

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObject()
    {
        // z offset is absolute value of the Camera's z position.
        Vector3 centerScreen = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10f));
        Instantiate(item, centerScreen, Quaternion.identity, parentObject.transform);
    }
}
