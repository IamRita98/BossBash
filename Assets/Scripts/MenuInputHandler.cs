using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInputHandler : MonoBehaviour
{
    //private variables but want them to be editable in the editor
    [SerializeField] private TextMeshProUGUI inputFieldText; // in case I cant implement the fancy replacing text in the menu
    [SerializeField] private string menuSelected;
    [SerializeField] private List<MenuOption> menuOptions = new();//the typed options
    private string curInput = "";
    SoundManager sm;
    PauseMenu pm;
    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.FindGameObjectWithTag("Sound Manager").GetComponent<SoundManager>();
        pm = GameObject.Find("Canvas").GetComponent<PauseMenu>();
        foreach(var opt in menuOptions)
        {
            opt.Initialize();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        foreach (char c in Input.inputString)
        {
            if (curInput.Length >= 20 && c!='\b') continue;
            if (c == '\b' && curInput.Length > 0)
            {
                curInput = curInput.Substring(0, curInput.Length - 1);
            }
            else if (c == '\n' || c == '\r') //  \n is apparently new line (linux) and \r is for windows 
            {
                ProcessInput(curInput.ToLower().Trim());
                curInput = "";
            }
            else if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
            {
                curInput += c;
            }
            UpdateMenuVisuals(curInput);
            inputFieldText.text = curInput;
        }

    }
    void UpdateMenuVisuals(string input)
    {
        foreach(var opt in menuOptions)
        {
            opt.UpdateVisual(input);
        }
    }
    void ProcessInput(string input)
    {
        switch (menuSelected)
        {
            case "main":
                HandleMainMenu(input);
                break;
            case "pause":
                HandlePauseMenu(input);
                break;
            case "levelMenu":
                HandleLevelSelectMenu(input);
                break;
            case "gameOver":
                HandleGameOverMenu(input);
                break;
        }
    }
    void HandleGameOverMenu(string input)
    {
        Scene scene = SceneManager.GetActiveScene();
        switch (input)
        {
            case "retry":
                SceneManager.LoadScene(scene.name);
                break;
            case "menu":
            case "main":
                SceneManager.LoadScene("Main Menu");
                break;
            case "quit":
            case "exit":
                Application.Quit();
                break;
        }
    }
    void HandleMainMenu(string input)
    {
        switch (input)
        {
            case "play":
            case "start":
                SceneManager.LoadScene("Level 1");
                sm.StartBtnClickSFX();
                //calll sound manager
                break;
            case "quit":
            case "exit":
                Application.Quit();
                break;
            case "courses":
            case "level":
            case "level select":
                SceneManager.LoadScene("Level Select");
                sm.BtnClickSFX();
                break;
            default:
                Debug.Log("Invalid input: " + input);
                break;
        }
    }
    void HandlePauseMenu(string input)
    {
        Scene scene = SceneManager.GetActiveScene();
        switch (input)
        {
            case "resume":
                pm.ResumeGame();
                break;
            case "retry":
                SceneManager.LoadScene(scene.name);
                break;
            case "menu":
            case "main":
                SceneManager.LoadScene("Main Menu");
                break;
            case "quit":
            case "exit":
                Application.Quit();
                break;
        }
    }
    void HandleLevelSelectMenu(string input)
    {
        switch(input)
        {
            case "act1":
            case "act 1":
                SceneManager.LoadScene("Level 1");
                sm.StartBtnClickSFX();
                break;
            case "act 2":
            case "act2":
                SceneManager.LoadScene("Level 2");
                sm.StartBtnClickSFX();
                break;
            case "act 3":
            case "act3":
                SceneManager.LoadScene("Level 3");
                sm.StartBtnClickSFX();
                break;
            case "return":
                SceneManager.LoadScene("Main Menu");
                sm.BtnClickSFX();
                break;
            default:
                Debug.Log("Invalid input: " + input);
                break;
        }
    }
}
