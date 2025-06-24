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

        textElement.SetText(finalString);
    }

    public void AddWord()
    {
        Word word = new Word(WordGenerator.GetRandomWord());
        words.Add(word);
    }
}
