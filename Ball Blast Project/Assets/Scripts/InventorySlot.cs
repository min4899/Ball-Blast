using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject item;
    public GameObject tooltip;
    public GameObject parentObject; // which parent to spawn under

    // Start is called before the first frame update
    void Start()
    {
        tooltip.SetActive(false);
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Enter");
        tooltip.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Exit");
        tooltip.SetActive(false);
    }
}
