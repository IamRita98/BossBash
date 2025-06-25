using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Splines;

public class RandomSpline : MonoBehaviour
{
    float timer;
    SplineAnimate sAnimate;
    public SplineContainer[] splines;

    private void Start()
    {
        sAnimate = gameObject.GetComponent<SplineAnimate>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > 3)
        {
            timer = 0;
            sAnimate.Container = splines[Random.Range(0, 2)];
        }
    }
}
