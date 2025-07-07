using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timerText;
    public TypingScenario currentScenario;

    PauseMenu pMenu;

    void Start()
    {
        timerIsRunning = true;
        timerText = GameObject.FindGameObjectWithTag("Countdown")?.GetComponent<TextMeshProUGUI>();
        timeRemaining = currentScenario.timeLimit;
        pMenu = GameObject.Find("Canvas").GetComponent<PauseMenu>();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                UpdateTimerDisplay(0);

                //TODO: Add in UI integration with actual countdown clock element
                Debug.Log("Timer ended");

                //GameOver for timeout
                pMenu.GameOver();
            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(0, timeToDisplay);
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
