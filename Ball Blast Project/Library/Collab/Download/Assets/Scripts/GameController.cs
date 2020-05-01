using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public Transform ballSpawn;

    public GameObject gameOverPanel;

    public static bool GameIsPaused = true;
    public static bool GameIsOver = false;

    public GameObject inventoryMenu;
    public CameraMovement camera;

    private GameObject ballReference;

    // Start is called before the first frame update
    void Start()
    {
        Pause();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void respawnBall()
    {
        if(ballReference != null)
            Destroy(ballReference);

        ballReference = Instantiate(ball, ballSpawn.position, Quaternion.identity);
        camera.ball = ballReference.transform;
    }

    void freezeObject()
    {
        //ballReference.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        ballReference.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    void unfreezeObject()
    {
        ballReference.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }

    public void Play()
    {
        if(GameIsPaused == false)
        {
            respawnBall();
        }
        if(!Drag.holdingObject) // player shouldnt be holding any object when pressing play
        {
            GameIsPaused = false;
            inventoryMenu.SetActive(false);
            unfreezeObject();
        }
        gameOverPanel.SetActive(false);
    }

    public void Pause()
    {
        respawnBall();
        GameIsPaused = true;
        inventoryMenu.SetActive(true);
        gameOverPanel.SetActive(false);
        freezeObject();
        camera.resetCamera();
    }
}
