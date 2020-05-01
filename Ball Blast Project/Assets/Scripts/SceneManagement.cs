using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void Start()
    {
        Debug.Log("Playing Level " + SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnMenu()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
