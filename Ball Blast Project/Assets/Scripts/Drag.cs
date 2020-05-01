using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;

    public static bool holdingObject = false;

    public float rotateSpeed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld == true)
        {
            moveTransform();

            if (Input.GetMouseButtonDown(1)) // set object down
            {
                isBeingHeld = false;
                Debug.Log("Placed " + gameObject.name);
                holdingObject = false;
            }
            if(Input.GetKeyDown(KeyCode.Backspace))
            {
                deleteObject();
            }
        }
    }

    private void OnMouseDown()
    {
        if(GameController.GameIsPaused && !holdingObject) // allow moving only when game is paused. check if another item is already held.
        {
            Debug.Log("Picked up " + gameObject.name);
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;
            holdingObject = true;
        }
    }

    private void moveTransform()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.Rotate(Vector3.forward * rotateSpeed, Space.Self);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.Rotate(Vector3.back * rotateSpeed, Space.Self);
        }
    }

    private void deleteObject()
    {
        Destroy(gameObject);
        holdingObject = false;
    }

    /*
    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        transform.right = direction;
    }
    */
}
