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

            textElement.text = outputText;
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
