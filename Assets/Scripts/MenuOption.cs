using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class MenuOption
{
    public string option;
    public TextMeshProUGUI optionLabel;

    private string fullText;
    public void Initialize()
    {
        if (string.IsNullOrWhiteSpace(option) || optionLabel == null)
        {
            Debug.LogWarning("not properly configured");
            return;
        }
        fullText = char.ToUpper(option[0]) + option.Substring(1);
        optionLabel.text = fullText;
    }

    // called every frame from menuinputhandler.update()
    public void UpdateVisual(string curInput)
    {
        if (optionLabel == null) return;
        if (string.IsNullOrEmpty(curInput))
        {
            optionLabel.text = fullText;
            return;
        }
        if (option.StartsWith(curInput.ToLower()))
        {
            string typed = fullText.Substring(0, curInput.Length);
            string remaining = new string(' ', fullText.Length - typed.Length);
            optionLabel.text = typed + remaining;
        }
        else
        {
            optionLabel.text = fullText;
        }
    }
}
