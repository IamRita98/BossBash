using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
    public GameObject gameOverMenu;
    public GameObject levelLayout;
    //GameManager gManager;

    public GameObject pauseImg;
    public GameObject gameOverImg;
    public GameObject textElements;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        textElements = GameObject.FindGameObjectWithTag("TextElements");
        //gManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
/*        if (pauseMenu.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeGame();
        }*/
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        pauseImg.SetActive(true);
        levelLayout.SetActive(false);
        textElements.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        gameOverImg.SetActive(true);
        levelLayout.SetActive(false);
        textElements.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        pauseImg.SetActive(false);
        levelLayout.SetActive(true);
        textElements.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
