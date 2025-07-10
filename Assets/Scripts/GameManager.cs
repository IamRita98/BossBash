using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentLevel = 1;

    public Sprite bossIdle;
    public Sprite bossAtk;
    public Sprite bossHurt;
    public Sprite bossHurt2;
    public Sprite playerIdle;
    public Sprite playerAtk;
    public Sprite playerAtk2;

    public SpriteRenderer playerSprite;
    public SpriteRenderer bossSprite;

    void OnEnable()
    {
        TypingInput.OnWordCompleted += HandleWordCompletion;
        TypingInput.OnLevelCompleted += HandleLevelCompletion;
    }

    void OnDisable()
    {
        TypingInput.OnWordCompleted -= HandleWordCompletion;
        TypingInput.OnLevelCompleted -= HandleLevelCompletion;
    }

    // TODO: Handle event on completed word - animation? visual indication? And launch an Update of UI of health bar and progress
    // -- Health bar and progress should only be updated on specific events being recieved, not on an update call as any change will be a direct result of a user input
    void HandleWordCompletion(TypingEventPayload completedWord)
    {
        Debug.Log("Completed word: " + completedWord.word);
        StartCoroutine(WordCompleteAnimations());
    }
    void HandleLevelCompletion(string scenarioName)
    {
        Debug.Log("Level completed: " + scenarioName);
        currentLevel++;
        if(currentLevel < 4)
        {
            SceneManager.LoadScene("Level " + currentLevel);
        }
        else
        {
            SceneManager.LoadScene("Main Menu");
        }
        
        //end current level and play a cut scene or something to move to next level or end game
    }

    IEnumerator WordCompleteAnimations()
    {
        int randomPic = Random.Range(0, 2);
        if (randomPic == 0)
        {
            playerSprite.sprite = playerAtk;
            bossSprite.sprite = bossHurt;
        }
        else if (randomPic == 1)
        {
            playerSprite.sprite = playerAtk2;
            bossSprite.sprite = bossHurt2;
        }
        yield return new WaitForSeconds(.5f);
        playerSprite.sprite = playerIdle;
        bossSprite.sprite = bossIdle;
    }
}