using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class TypingInput : MonoBehaviour
{
    private TextMeshProUGUI textElement;
    private TextMeshProUGUI topTextElement;
    private string rawInput;
    private string outputText;
    private bool isInitialized = false;

    void Update()
    {

        if (!isInitialized)
        {
            textElement = GameObject.FindGameObjectWithTag("UserInput")?.GetComponent<TextMeshProUGUI>();
            topTextElement = GameObject.FindGameObjectWithTag("TopText")?.GetComponent<TextMeshProUGUI>();

            if (textElement != null && topTextElement != null)
            {
                isInitialized = true;
            }

            return;
        }

        else
        {
            rawInput = StripColorTags(textElement.text);
            string inputString = textElement.text ?? "";
            string topTextString = topTextElement.text ?? "";

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

            int divergenceIndex = GetDivergenceIndex(rawInput, topTextString);

            if (divergenceIndex == 0)
            {
                outputText = "<color=red>" + rawInput + "</color>";
            }
            else if (divergenceIndex < rawInput.Length)
            {
                outputText = "<color=green>" + rawInput.Substring(0, divergenceIndex) + "</color>" + "<color=red>" + rawInput.Substring(divergenceIndex) + "</color>";
            }
            else
            {
                outputText = "<color=green>" + rawInput + "</color>";
            }

<<<<<<< Updated upstream
            textElement.text = outputText;
=======
            // Word matched, trigger event for any subscribers to respond and reset the user input - see GameManager for reference
            if (rawInput == topTextString)
            {
                correctWords += rawInput.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Length;
                TypingEventPayload typingEventPayload = new TypingEventPayload(rawInput, totalWordCount, correctWords);
                OnWordCompleted?.Invoke(typingEventPayload);
                typingConfig.Remove(rawInput);
                rawInput = "";
                outputText = "";
                if (typingConfig.Count > 0)
                {
                    topTextElement.text = typingConfig[0];
                }
                else
                {
                    topTextElement.text = "";
                    OnLevelCompleted?.Invoke(currentScenario.scenarioName);
                }
            }

            userInputText.text = outputText;
>>>>>>> Stashed changes
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
