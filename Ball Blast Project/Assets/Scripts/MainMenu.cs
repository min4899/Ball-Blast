using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject howToScreen;
    public GameObject levelSelect;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        howToScreen.SetActive(false);
        levelSelect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMain()
    {
        mainMenu.SetActive(true);
        howToScreen.SetActive(false);
        levelSelect.SetActive(false);
    }

    public void GoToHowToScreen()
    {
        mainMenu.SetActive(false);
        howToScreen.SetActive(true);
        levelSelect.SetActive(false);
    }

    public void GoToLevelSelectScreen()
    {
        mainMenu.SetActive(false);
        howToScreen.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void LevelSelect(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
