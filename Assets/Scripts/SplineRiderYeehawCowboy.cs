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
        sAnimator.Duration = (float)tInput.currentProcessedLine.timeAllowed;
    }
    void ResetSplinePos(TypingEventPayload completedWord)
    {
        sAnimator.Restart(false);
    }
    public void StartSpline()
    {
        sAnimator.Play();
    }
}
