using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Splines;

public class RandomSpline : MonoBehaviour
{
    float timer;
    SplineAnimate sAnimate;
    float splineLength = 3; //This is hardcoded for now but it should be whatever length of time the splines are set for their movement
    public SplineContainer[] splines;

    private void Start()
    {
        sAnimate = gameObject.GetComponent<SplineAnimate>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > splineLength)
        {
            timer = 0;
            sAnimate.Container = splines[Random.Range(0, splines.Length + 1)];
        }
    }
}
