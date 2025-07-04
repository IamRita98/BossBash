using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageMovement : MonoBehaviour
{
    [SerializeField] private PlayerHurtZone hurtZone;
    [SerializeField] int desiredHP;

    // Transition speed (adjust as needed)
    [SerializeField] private float transitionSpeed = 2f;

    private Vector3 targetPosition;
    private Vector3 targetScale;

    void Start()
    {
        hurtZone = GetComponent<PlayerHurtZone>();
        SetTargets(hurtZone.playerHP);
        // Optionally, set initial position/scale to match targets
        transform.position = targetPosition;
        transform.localScale = targetScale;
    }

    void Update()
    {
        // Debugging: set playerHP based on desiredHP
        if (desiredHP == 1)
            hurtZone.playerHP = 1;
        else if (desiredHP == 2)
            hurtZone.playerHP = 2;
        else
            hurtZone.playerHP = 3;

        SetTargets(hurtZone.playerHP);

        // Smoothly interpolate position and scale
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * transitionSpeed);
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * transitionSpeed);
    }

    private void SetTargets(int hp)
    {
        if (hp == 3)
        {
            targetPosition = new Vector3(0, 3, -11);
            targetScale = new Vector3(1, 1, 1);
        }
        else if (hp == 2)
        {
            targetPosition = new Vector3(0, 2, -11);
            targetScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (hp == 1)
        {
            targetPosition = new Vector3(0, 1, -11);
            targetScale = new Vector3(2, 2, 2);
        }
    }
}