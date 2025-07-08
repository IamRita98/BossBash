using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class BossDamageMovement : MonoBehaviour
{
    [SerializeField] private PlayerHurtZone hurtZone;
    [SerializeField] int desiredHP;

    // Transition speed (adjust as needed)
    [SerializeField] private float transitionSpeed = 2f;

    private Vector3 targetPosition;
    private Vector3 targetScale;
    private Quaternion targetRotation;
    private float transitionSpeedInitial = 5f;
    private float transitionSpeedActual = 2f;
    private Transform goTransform;
    public GameObject pos1GO;
    public GameObject pos2GO;
    public GameObject pos3GO;
    public GameObject posOffScreen;
    public float timeToWait = 3.5f;
    bool hasRotated2 = false;
    bool hasRotated1 = false;
    bool hasEnteredScreen = false;
    void Start()
    {
        hurtZone = GetComponent<PlayerHurtZone>();
        //SetTargets(hurtZone.playerHP);
        // Initialize the target position and scale based on the current player HP
        transform.position = posOffScreen.transform.position;
        //transform.localScale = targetScale;
       // rotationZ = gameObject.GetComponent<Transform>().rotation.z;
        goTransform = gameObject.GetComponent<Transform>();
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
        //Vector3 currentPosition = transform.position;

        // Smoothly interpolate position and scale
        if (hasEnteredScreen == false)
        {
            transitionSpeed = transitionSpeedInitial;
            hasEnteredScreen = true;
        }
        if (Vector3.Distance(pos1GO.transform.position, transform.position) < 2)
        {
            Debug.Log("Changing trans speed");
            transitionSpeed = transitionSpeedActual;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * transitionSpeed);
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * transitionSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * transitionSpeed);
    }

    private void SetTargets(int hp)
    {
        switch (hp)
        {
            case 3:
                targetPosition = new Vector3(0, 3, -11);
                targetScale = new Vector3(1, 1, 1);
                break;
            case 2:
                //targetPosition = new Vector3(-10.54f, 0.369434267f, -12.0000744f);
                targetPosition = pos2GO.transform.position;
                targetScale = new Vector3(1.75f, 1.75f, 1.75f);
                if (!hasRotated2)
                {
                    hasRotated2 = true;
                    targetRotation = Quaternion.Euler(0, 0, 25f);
                    StartCoroutine(BossTimer());
                }
                break;
            case 1:
                //targetPosition = new Vector3(-10.6599998f, -1.96000004f, -12.0000143f);
                targetPosition = pos3GO.transform.position;
                targetScale = new Vector3(2, 2, 2);
                if (!hasRotated1)
                {
                    hasRotated1 = true;
                    targetRotation = Quaternion.Euler(0, 0, -25);
                    StartCoroutine(BossTimer());
                }
                break;
            case 0:
                //Debug.Log("Game Over bich");
                break;
            default:
                targetPosition = Vector3.zero; // Fallback position
                targetScale = Vector3.one; // Fallback scale
                Debug.Log("Something fucked hpwise");
                //targetPosition = Vector3.zero;
                //targetScale = Vector3.one;
                break;
        }
    }
    IEnumerator BossTimer()
    {
        yield return new WaitForSeconds(timeToWait);
        targetRotation = Quaternion.Euler(0, 0, 0);
    }
}