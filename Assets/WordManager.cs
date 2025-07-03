using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    public List<string> typingConfig;

    public TypingScenario currentScenario;

    public GameObject textObject;

    private void Start()
    {
        textObject = GameObject.FindGameObjectWithTag("TopText");
        GetTypingConfig();

        if (currentScenario.scenarioName.Equals("LevelOne")) {
            TextMeshProUGUI textElement = textObject.GetComponent<TextMeshProUGUI>();
            textElement.SetText(typingConfig[0]);
        }else if (currentScenario.scenarioName.Equals("LevelTwo")){
            TextMeshProUGUI textElement = textObject.GetComponent<TextMeshProUGUI>();
            textElement.SetText(typingConfig[0]);
        }
        else if (currentScenario.scenarioName.Equals("LevelThree"))
        {
            TextMeshProUGUI textElement = textObject.GetComponent<TextMeshProUGUI>();
            textElement.SetText(typingConfig[0]);
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    //May need to expand as TypingConfig grows past initial sentence value
    public void GetTypingConfig()
    {
        typingConfig = TypingConfig.GetTypingConfig(currentScenario.scenarioName);
    }
}
