using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BossDamageMovement : MonoBehaviour
{
    [SerializeField] private PlayerHurtZone hurtZone;
    [SerializeField] int desiredHP;

    [SerializeField] private float transitionSpeed = 2f;

    private Vector3 targetPosition;
    private Vector3 targetScale;
    private Quaternion m_LocalRotation;


    void Start()
    {
        hurtZone = GetComponent<PlayerHurtZone>();
        SetTargets(hurtZone.playerHP);

        transform.position = targetPosition;
        transform.localScale = targetScale;
    }

    void Update()
    {
        // Debugging: set playerHP based on desiredHP
        if (desiredHP == 1)
            hurtZone.playerHP = 1;
        else if (desiredHP == 0)
            hurtZone.playerHP = 0;
        else if (desiredHP == 2)
            hurtZone.playerHP = 2;
        else
            hurtZone.playerHP = 3;

        SetTargets(hurtZone.playerHP);

        // Store current position before moving
        Vector3 currentPosition = transform.position;

        // Smoothly interpolate position and scale
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * transitionSpeed);
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * transitionSpeed);

        // Check if moving (distance to target is significant)
        bool isMoving = (Vector3.Distance(transform.position, targetPosition) > 1.10f);
    }

    private void SetTargets(int hp)
    {
        switch (hp)
        {
            case 3:
                targetPosition = new Vector3(-8.053792f, 2.41930938f, -12.9552612f);
                targetScale = new Vector3(1.5f, 1.5f, 1.5f);
                break;
            case 2:
                targetPosition = new Vector3(-10.54f, 0.369434267f, -12.0000744f);
                targetScale = new Vector3(1.75f, 1.75f, 1.75f);
                break;
            case 1:
                targetPosition = new Vector3(-10.6599998f, -1.96000004f, -12.0000143f);
                targetScale = new Vector3(2, 2, 2);
                break;
            case 0:
                break;
            default:
                targetPosition = Vector3.zero;
                targetScale = Vector3.one;
                break;
        }
    }
}