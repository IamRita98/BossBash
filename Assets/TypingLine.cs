using UnityEngine;

[System.Serializable]
public class TypingLine
{
    public string entity;         
    public string textToType;
    public float timeLimitSeconds; //If -1, that means there is no time limit (ie, level 1)

    public TypingLine(string entity, string textToType, float timeLimitSeconds)
    {
        this.entity = entity;
        this.textToType = textToType;
        this.timeLimitSeconds = timeLimitSeconds;
    }
}