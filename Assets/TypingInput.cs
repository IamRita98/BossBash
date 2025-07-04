using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class TypingInput : MonoBehaviour
{
    private TextMeshProUGUI userInputText;
    private TextMeshProUGUI topTextElement;
    private TextMeshProUGUI playerDialogueTextElement;
    private string rawInput;
    private string outputText;
    private bool isInitialized = false;
    private bool hasCompletedWord = false;
    private bool isAdvancingLine = false;

    public TypingScenario currentScenario;
    public static event System.Action<TypingEventPayload> OnWordCompleted;
    public static event System.Action<string> OnLevelCompleted;
    private List<TypingLine> activeTypingLines = new();
    private float currentTime = 0f;
    public List<TypingLine> typingConfig;
    public int totalWordCount;
    public int correctWords;

    public void Start()
    {
        InitializeTypingScenario();
        typingConfig = TypingConfig.GetTypingConfig(currentScenario.scenarioName);
        correctWords = 0;
        List<TypingLine> enemyLines = typingConfig
            .Where(item => item.entity == "enemy")
            .ToList();
        List<TypingLine> playerLines = typingConfig
            .Where(item => item.entity != "enemy")
            .ToList();
        totalWordCount = enemyLines
            .SelectMany(line => line.textToType.Split((char[])null, StringSplitOptions.RemoveEmptyEntries))
            .Count();

        Debug.Log("Total character count for boss dialogue to type (excluding whitespace): " + totalWordCount);
    }

    void Update()
    {
        if (!isInitialized)
        {
            TryInitializeUIReferences();
            return;
        }

        if (typingConfig == null || typingConfig.Count == 0) return;

        ProcessUserInput();
        UpdateColoredText();
        CheckForWordCompletion();
    }

    private void InitializeTypingScenario()
    {
        typingConfig = TypingConfig.GetTypingConfig(currentScenario.scenarioName);
        correctWords = 0;

        var enemyLines = typingConfig
            .Where(item => item.entity == "enemy")
            .ToList();

        totalWordCount = enemyLines
            .SelectMany(line => line.textToType.Split((char[])null, StringSplitOptions.RemoveEmptyEntries))
            .Count();
    }

    private void TryInitializeUIReferences()
    {
        userInputText = GameObject.FindGameObjectWithTag("UserInput")?.GetComponent<TextMeshProUGUI>();
        topTextElement = GameObject.FindGameObjectWithTag("TopText")?.GetComponent<TextMeshProUGUI>();
        playerDialogueTextElement = GameObject.FindGameObjectWithTag("PlayerDialogue")?.GetComponent<TextMeshProUGUI>();

        if (userInputText != null && topTextElement != null && playerDialogueTextElement != null)
        {
            isInitialized = true;
            userInputText.text = "";
            playerDialogueTextElement.text = "";
        }
    }

    private void ProcessUserInput()
    {
        rawInput = StripColorTags(userInputText.text);

        foreach (char c in Input.inputString)
        {
            if (c == '\b' && rawInput.Length > 0)
            {
                rawInput = rawInput.Substring(0, rawInput.Length - 1);
            }
            else
            {
                rawInput += c;
            }
        }
    }

    private void UpdateColoredText()
    {
        string targetText = topTextElement.text ?? "";
        int divergenceIndex = GetDivergenceIndex(rawInput, targetText);

        if (divergenceIndex == 0)
        {
            outputText = $"<color=red>{rawInput}</color>";
        }
        else if (divergenceIndex < rawInput.Length)
        {
            outputText =
                $"<color=green>{rawInput.Substring(0, divergenceIndex)}</color>" +
                $"<color=red>{rawInput.Substring(divergenceIndex)}</color>";
        }
        else
        {
            outputText = $"<color=green>{rawInput}</color>";
        }

        userInputText.text = outputText;
    }

    private void CheckForWordCompletion()
    {
        string targetText = topTextElement.text ?? "";

        if (rawInput == targetText)
        {
            correctWords += rawInput.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Length;
            OnWordCompleted?.Invoke(new TypingEventPayload(rawInput, totalWordCount, correctWords));
            typingConfig.RemoveAt(0);
            
            rawInput = "";
            outputText = "";
            userInputText.text = "";

            AdvanceToNextTypingLine();
        }
    }

    //Could change this to a coroutine to introduce a delay before going to the next line - used for an animation
    private void AdvanceToNextTypingLine()
    {
        while (typingConfig.Count > 0 && typingConfig[0].entity == "Player")
        {
            playerDialogueTextElement.text = typingConfig[0].textToType;
            typingConfig.RemoveAt(0);
        }

        if (typingConfig.Count > 0)
        {
            topTextElement.text = typingConfig[0].textToType;
        }
        else
        {
            topTextElement.text = "";
            OnLevelCompleted?.Invoke(currentScenario.scenarioName);
        }
    }


    int GetDivergenceIndex(string a, string b)
    {
        int minLength = Mathf.Min(a.Length, b.Length);

        for (int i = 0; i < minLength; i++)
        {
            if (a[i] != b[i])
                return i;
        }

        return minLength;
    }

    string StripColorTags(string input)
    {
        return Regex.Replace(input, "<color=.*?>|</color>", "");
    }

}

[System.Serializable]
public class TypingEventPayload
{
    public string word;
    public int totalWordsInScenario;
    public int wordsCompleted;

    public TypingEventPayload(string word, int totalWordsInScenario, int wordsCompleted)
    {
        this.word = word;
        this.totalWordsInScenario = totalWordsInScenario;
        this.wordsCompleted = wordsCompleted;
    }
}

public class ActiveTypingLine
{
    public TypingLine line;
    public float expirationTime;
    public GameObject textObject; // To display it on screen
}
