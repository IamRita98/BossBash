using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class WordManager : MonoBehaviour
{
    public List<Word> words;

    public GameObject textObject;
    //public GameObject wordText;

    private void Start()
    {
        textObject = GameObject.FindGameObjectWithTag("TopText");
        AddWord();
        AddWord();
        AddWord();
        TextMeshProUGUI textElement = textObject.GetComponent<TextMeshProUGUI>();
        string finalString = string.Join(" ", words.Select(w => w.word));

<<<<<<< Updated upstream
        textElement.SetText(finalString);
=======
        if (currentScenario.scenarioName.Equals("LevelOne")) {
            TextMeshProUGUI textElement = textObject.GetComponent<TextMeshProUGUI>();
            textElement.SetText(typingConfig[0]);
        }else if (currentScenario.scenarioName.Equals("LevelTwo")) {
            TextMeshProUGUI textElement = textObject.GetComponent<TextMeshProUGUI>();
            textElement.SetText(typingConfig[0]);
        }
>>>>>>> Stashed changes
    }

    public void AddWord()
    {
        Word word = new Word(WordGenerator.GetRandomWord());
        words.Add(word);
    }
}
