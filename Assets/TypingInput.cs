using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class TypingInput : MonoBehaviour
{
    private string rawInput;
    private string outputText;
    private bool isInitialized = false;
    private HashSet<TypingLine> spawnedLines = new HashSet<TypingLine>();
    private Dictionary<TypingLine, GameObject> spawnedTextObjects = new();
    private Dictionary<string, TextMeshProUGUI> uiTextElements = new();

    public TypingScenario currentScenario;
    public static event System.Action<TypingEventPayload> OnWordCompleted;
    public static event System.Action<string> OnLevelCompleted;
    private List<TypingLine> activePrompts = new List<TypingLine>();
    private TextMeshProUGUI currentActiveTextToType;
    private string[] textTags = { "UserInput", "MainDisplayText", "PlayerDialogue", "PopoutWordPlaceholder1", "PopoutWordPlaceholder2", "PopoutWordPlaceholder3", "PopoutWordPlaceholder4" };

    private double timeAtWordStart = 0;
    private double currentTime;
    private int currentProcessedLineIndex;
    private TypingLine currentProcessedLine;

    public List<TypingLine> typingConfig;
    public List<TypingLine> enemyLines;
    public int totalWordCount;
    public int correctWords;

    public SoundManager sManage;

    public void Start()
    {
        InitializeTypingScenario();
        sManage = GameObject.FindGameObjectWithTag("Sound Manager").GetComponent<SoundManager>();
    }

    void Update()
    {
        currentTime = Time.timeSinceLevelLoadAsDouble;
        if (!isInitialized)
        {
            // TODO: Break this list up in the scriptable object assigned in the level so we don't have to maintain this list for every level in code
            if (currentScenario.scenarioName == "LevelOne")
            {
                TryInitializeUIReferences(new[] { "UserInput", "MainDisplayText", "PlayerDialogue" });
            }
            else
            {
                TryInitializeUIReferences(new[] { "UserInput", "MainDisplayText", "PlayerDialogue", "PopoutWordPlaceholder1", "PopoutWordPlaceholder2", "PopoutWordPlaceholder3", "PopoutWordPlaceholder4" });
            }
            return;
        }

        if (typingConfig == null || typingConfig.Count == 0) return;

        if (currentScenario.scenarioName == "LevelTwo" || currentScenario.scenarioName == "LevelThree") {
           ProcessPromptExpirations();
        }
        ProcessUserInput();

        // Color progress should only appear for non-trivia questions
        UpdateColoredText();
        CheckForWordCompletion();
    }

    private void ProcessPromptExpirations()
    {
        if (!uiTextElements.TryGetValue("UserInput", out var userInputText)) return;
        
        // Gone over the word time limit
        if (currentTime > timeAtWordStart + currentProcessedLine.timeAllowed)
        {
            userInputText.text = "";
            ClearTextGameObjects();
            // Send event to remove healthbar\
            
            currentProcessedLineIndex += 1;
            while (currentProcessedLineIndex < typingConfig.Count && typingConfig[currentProcessedLineIndex].entity != "Enemy")
            {
                currentProcessedLineIndex += 1;
            } 
            currentProcessedLine = typingConfig[currentProcessedLineIndex];
            SpawnNextLine();
            timeAtWordStart = currentTime;
        }
    }

    void ClearTextGameObjects()
    {
        uiTextElements.TryGetValue("UserInput", out var UserInputLineTextVar);
        uiTextElements.TryGetValue("MainDisplayText", out var MainDisplayLineTextVar);
        uiTextElements.TryGetValue("PlayerDialogue", out var playerDialogueTextVar);
        UserInputLineTextVar.text = "";
        MainDisplayLineTextVar.text = "";
        playerDialogueTextVar.text = "";
        if (currentScenario.scenarioName == "LevelTwo" || currentScenario.scenarioName == "LevelThree")
        {
            uiTextElements.TryGetValue("PopoutWordPlaceholder1", out var PopoutWordPlaceholder1TextVar);
            uiTextElements.TryGetValue("PopoutWordPlaceholder2", out var PopoutWordPlaceholder2TextVar);
            uiTextElements.TryGetValue("PopoutWordPlaceholder3", out var PopoutWordPlaceholder3TextVar);
            uiTextElements.TryGetValue("PopoutWordPlaceholder4", out var PopoutWordPlaceholder4TextVar);
            PopoutWordPlaceholder1TextVar.text = "";
            PopoutWordPlaceholder2TextVar.text = "";
            PopoutWordPlaceholder3TextVar.text = "";
            PopoutWordPlaceholder4TextVar.text = "";
        }
    }

    void SpawnNextLine()
    {
        if (currentProcessedLine.IsTrivia)
        {
            uiTextElements.TryGetValue("MainDisplayText", out var MainDisplayTextVar);
            MainDisplayTextVar.text = currentProcessedLine.triviaQuestion;

            uiTextElements.TryGetValue("PopoutWordPlaceholder1", out var PopoutWordPlaceholder1TextVar);
            uiTextElements.TryGetValue("PopoutWordPlaceholder2", out var PopoutWordPlaceholder2TextVar);
            uiTextElements.TryGetValue("PopoutWordPlaceholder3", out var PopoutWordPlaceholder3TextVar);
            uiTextElements.TryGetValue("PopoutWordPlaceholder4", out var PopoutWordPlaceholder4TextVar);
            PopoutWordPlaceholder1TextVar.text = currentProcessedLine.answerOptions[0];
            PopoutWordPlaceholder2TextVar.text = currentProcessedLine.answerOptions[1];
            PopoutWordPlaceholder3TextVar.text = currentProcessedLine.answerOptions[2];
            PopoutWordPlaceholder4TextVar.text = currentProcessedLine.answerOptions[3];
        }
        else
        {
            currentActiveTextToType = GameObject.FindGameObjectWithTag(currentProcessedLine.textGameTag)?.GetComponent<TextMeshProUGUI>();
            currentActiveTextToType.text = currentProcessedLine.textToType;
        }
    }

    private void InitializeTypingScenario()
    {
        typingConfig = TypingConfig.GetTypingConfig(currentScenario.scenarioName);
        correctWords = 0;

        enemyLines = typingConfig
            .Where(item => item.entity == "Enemy")
            .ToList();

        totalWordCount = enemyLines
            .SelectMany(line => line.textToType.Split((char[])null, StringSplitOptions.RemoveEmptyEntries))
            .Count();
    }

    private void TryInitializeUIReferences(string[] tags)
    {
        foreach (string tag in tags)
        {
            GameObject go = GameObject.FindGameObjectWithTag(tag);
            if (go != null)
            {
                TextMeshProUGUI tmp = go.GetComponent<TextMeshProUGUI>();
                if (tmp != null)
                {
                    uiTextElements[tag] = tmp;
                    if (currentScenario.scenarioName == "LevelTwo" || currentScenario.scenarioName == "LevelThree") tmp.text = "";
                }
                else
                {
                    Debug.LogWarning($"No TextMeshProUGUI on GameObject with tag '{tag}'");
                }
            }
            else
            {
                return;
            }
            if(currentProcessedLine.entity == "Enemy")
            {
                sManage.OnBossSpeakingSFX();
            }
        }
        currentProcessedLineIndex = 0;
        currentProcessedLine = typingConfig[0];
        Debug.Log($"Initial line: {currentProcessedLine.textToType}");
        SpawnNextLine();
        isInitialized = true;
    }

    private void ProcessUserInput()
    {
        uiTextElements.TryGetValue("UserInput", out var currentLineTextVar);
        rawInput = StripColorTags(currentLineTextVar?.text ?? "");

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
        if (!uiTextElements.TryGetValue("MainDisplayText", out var mainDisplayText)) return;
        if (!uiTextElements.TryGetValue("UserInput", out var userInputText)) return;

        if (currentProcessedLine.IsTrivia)
        {
            string triviaTargetText = currentProcessedLine.answerOptions[currentProcessedLine.correctAnswerIndex];
            userInputText.text = rawInput;
        }
        else {
            string targetText = currentActiveTextToType.text;
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
    }

    private void CheckForWordCompletion()
    {
        if (!uiTextElements.TryGetValue("UserInput", out var userInputText)) return;

        if (currentProcessedLine.IsTrivia)
        {
            for (int i = 0; i < currentProcessedLine.answerOptions.Count; i++)
            {
                if (rawInput == currentProcessedLine.answerOptions[i])
                {
                    bool isCorrect = i == currentProcessedLine.correctAnswerIndex;

                    if (isCorrect)
                    {
                        correctWords++;
                        OnWordCompleted?.Invoke(new TypingEventPayload(rawInput, totalWordCount, correctWords));
                    }
                    else
                    {
                        // Send event for word failed
                        Debug.Log("Wrong Answer");
                    }

                    rawInput = "";
                    userInputText.text = "";
                    AdvanceToNextTypingLine();
                    return;
                }
            }
        }
        else { 
            string targetText = currentActiveTextToType.text;
            if (rawInput == targetText)
            {
                correctWords += rawInput.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Length;
                OnWordCompleted?.Invoke(new TypingEventPayload(rawInput, totalWordCount, correctWords));

                rawInput = "";
                outputText = "";
                userInputText.text = "";
                AdvanceToNextTypingLine();
            }
        }
    }

    //Could change this to a coroutine to introduce a delay before going to the next line - used for an animation
    private void AdvanceToNextTypingLine()
    {
        if (!uiTextElements.TryGetValue("PlayerDialogue", out var playerDialogueTextVar)) return;
        if (!uiTextElements.TryGetValue("MainDisplayText", out var mainDisplayTextVar)) return;

        ClearTextGameObjects();
        Debug.Log($"Advancing to next line at line: {currentProcessedLine.textToType}");
        currentProcessedLineIndex += 1;
        while (currentProcessedLineIndex < typingConfig.Count && typingConfig[currentProcessedLineIndex].entity != "Enemy")
        {
            playerDialogueTextVar.text = typingConfig[currentProcessedLineIndex].textToType;
            currentProcessedLineIndex += 1;
        }
        currentProcessedLine = typingConfig[currentProcessedLineIndex];
        SpawnNextLine();
        timeAtWordStart = currentTime;

        if( currentProcessedLineIndex >= typingConfig.Count )
        {
            mainDisplayTextVar.text = "";
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

// Used for levels 2 and 3
public class TimedText
{
    public TextMeshProUGUI textObject;
    public float expirationTime;
}
