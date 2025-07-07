using UnityEngine;

[System.Serializable]
public class TypingLine
{
    public string entity;         
    public string textToType;
    public string textGameTag; //Tag of UI text mesh element to assign the text to. This is to handle the case of popout text elements, 
    public double timeAllowed;

    public TypingLine(string entity, string textToType, double timeAllowed = -1, string textGameTag = "MainDisplayText")
    {
        this.entity = entity;
        this.textToType = textToType;
        this.timeAllowed = timeAllowed;
        this.textGameTag = textGameTag;
    }
}