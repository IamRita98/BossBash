using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineRiderYeehawCowboy : MonoBehaviour
{
    SplineAnimate sAnimator;
    TypingInput tInput;

    private void Start()
    {
        sAnimator = GetComponent<SplineAnimate>();
        tInput = GameObject.Find("TypingInput").GetComponent<TypingInput>();
        TypingInput.OnWordCompleted += ResetSplinePos;
    }
    private void Update()
    {
        //sAnimator.Duration = (float)tInput.currentProcessedLine.timeAllowed;
        if(sAnimator.Duration == 0)
        {
            sAnimator.Restart(false);
        }
    }
    void ResetSplinePos(TypingEventPayload completedWord)
    {
        if(sAnimator.Container == null)
        {
            return;
        }
        sAnimator.Duration = (float)tInput.currentProcessedLine.timeAllowed;
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
