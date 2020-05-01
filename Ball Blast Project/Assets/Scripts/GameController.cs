using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public Transform ballSpawn;

    public GameObject gameOverPanel;
    public GameObject levelClearedPanel;

    public static bool GameIsPaused = true;
    public static bool GameIsOver = false;

    public GameObject inventoryMenu;
    public CameraMovement camera;

    public Text finalTime;
    public Text objectCount;
    public Transform playerObjects;

    private GameObject ballReference;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameIsPaused && !GameIsOver)
        {
            timer += Time.deltaTime;
        }
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
        //ballReference.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        ballReference.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    void unfreezeObject()
    {
        //ballReference.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        ballReference.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    public void Play()
    {
        if(GameIsPaused && !Drag.holdingObject) // player shouldnt be holding any object when pressing play, game shouldnt already be playing.
        {
            Debug.Log("Game Resumed.");
            GameIsPaused = false;
            inventoryMenu.SetActive(false);
            levelClearedPanel.SetActive(false);
            unfreezeObject();
            gameOverPanel.SetActive(false);
        }
        if(GameIsOver)
            GameIsOver = false;
    }

    public void Pause()
    {
        Debug.Log("Game Paused.");
        respawnBall();
        freezeObject();
        GameIsPaused = true;
        timer = 0;
        inventoryMenu.SetActive(true);
        gameOverPanel.SetActive(false);
        levelClearedPanel.SetActive(false);
        camera.resetCamera();
    }

    public void FinishLevel()
    {
        Debug.Log("Level Completed.");
        GameIsOver = true;

        int minutes = (int)timer / 60;
        int seconds = (int)timer - 60 * minutes;
        int milliseconds = (int)(1000 * (timer - minutes * 60 - seconds));
        finalTime.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        objectCount.text = playerObjects.childCount.ToString();

        inventoryMenu.SetActive(false);
        gameOverPanel.SetActive(false);
        levelClearedPanel.SetActive(true);
    }
}
