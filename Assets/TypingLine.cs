using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TypingLine
{
    public string entity;         
    public string textToType;
    public string textGameTag; //Tag of UI text mesh element to assign the text to. This is to handle the case of popout text elements, 
    public double timeAllowed;

    public string triviaQuestion;
    public List<string> answerOptions;
    public int correctAnswerIndex;

    public bool IsTrivia => !string.IsNullOrEmpty(triviaQuestion);

    public string CorrectAnswer => (IsTrivia)
        ? answerOptions[correctAnswerIndex]
        : null;


    public TypingLine(string entity, string textToType, double timeAllowed = -1, string textGameTag = "MainDisplayText")
    {
        this.entity = entity;
        this.textToType = textToType;
        this.timeAllowed = timeAllowed;
        this.textGameTag = textGameTag;
    }

    public TypingLine(string entity, string triviaQuestion, List<string> answerOptions, int correctAnswerIndex, string textGameTag = "MainDisplayText", double timeAllowed = -1)
    {
        this.entity = entity;
        this.timeAllowed = timeAllowed;
        this.textGameTag = textGameTag;
        this.triviaQuestion = triviaQuestion;
        this.answerOptions = answerOptions;
        this.correctAnswerIndex = correctAnswerIndex;
        this.textToType = triviaQuestion;
    }
}