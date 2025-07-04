using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Make sure to change source
        SceneManager.LoadScene("Level 1");
    }

    public void Replay()
    {
        // Make sure to change source
        SceneManager.LoadScene("Level 1");
    }

    public void Endless()
    {
        //SceneManager.LoadScene("Pause");
        return; //Lets do nothing on pressing endless for now
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        // Make sure to change source
        SceneManager.LoadScene("Main Menu");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void PlayAct1()
    {
        // Make sure to change source
        SceneManager.LoadScene("Level 1");
    }

    public void PlayAct2()
    {
        // Make sure to change source
        SceneManager.LoadScene("Level 2");
    }

    public void PlayAct3()
    {
        // Make sure to change source
        SceneManager.LoadScene("Level 3");
    }
}