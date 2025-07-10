using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineRiderYeehawCowboy : MonoBehaviour
{
    SplineAnimate sAnimator;
    TypingInput tInput;
    float timer = 0;

    private void Start()
    {
        sAnimator = GetComponent<SplineAnimate>();
        tInput = GameObject.Find("TypingInput").GetComponent<TypingInput>();
        TypingInput.OnWordCompleted += ResetSplinePos;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        sAnimator.Duration = (float)tInput.currentProcessedLine.timeAllowed;
        if(timer >= tInput.currentProcessedLine.timeAllowed)
        {
            sAnimator.Restart(false);
            timer = 0;
        }
    }
    void ResetSplinePos(TypingEventPayload completedWord)
    {
        if(sAnimator.Container == null)
        {
            return;
        }
        timer = 0;
        //sAnimator.Duration = (float)tInput.currentProcessedLine.timeAllowed;
        sAnimator.Restart(false);
    }
    public void StartSpline()
    {
        if(sAnimator.Container == null)
        {
            return;
        }
        sAnimator.Play();
    }
}
