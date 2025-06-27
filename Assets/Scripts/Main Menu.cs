using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Replay()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Endless()
    {
        SceneManager.LoadScene("Pause");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}