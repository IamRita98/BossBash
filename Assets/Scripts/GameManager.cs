using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentLevel = 1;

    void OnEnable()
    {
        TypingInput.OnWordCompleted += HandleWordCompletion;
    }

    void OnDisable()
    {
        TypingInput.OnWordCompleted -= HandleWordCompletion;
    }

    // TODO: Handle event on completed word - animation? visual indication? And launch an Update of UI of health bar and progress
    // -- Health bar and progress should only be updated on specific events being recieved, not on an update call as any change will be a direct result of a user input
    void HandleWordCompletion(string completedWord)
    {
        Debug.Log("Completed word: " + completedWord);
    }
}