using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class BossDamageMovement : MonoBehaviour
{
    [SerializeField] private PlayerHurtZone hurtZone;

    // Transition speed (adjust as needed)
    [SerializeField] private float transitionSpeed = 2f;

    private Vector3 targetPosition;
    private Vector3 targetScale;
    private Quaternion targetRotation;
    private float transitionSpeedInitial = 5f;
    private float transitionSpeedActual = 2f;
    private float transitionScaleSpeed = 1;
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
        hurtZone = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHurtZone>();
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
            transitionSpeed = transitionSpeedActual;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * transitionSpeed);
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * transitionScaleSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * transitionSpeed);
    }

    private void SetTargets(int hp)
    {
        switch (hp)
        {
            case 3:
                targetPosition = pos1GO.transform.position;
                targetScale = new Vector3(1.5f, 1.5f, 1.5f);
                break;
            case 2:
                PlayerHP2BossBehaviour(ref hasRotated2);
                break;
            case 1:
                PlayerHP1BossBehaviour(ref hasRotated1);
                break;
            case 0:
                //Debug.Log("Game Over bich");
                break;
            default:
                Debug.Log("Something fucked hpwise");
                break;
        }
    }

    IEnumerator BossTimer()
    {
        yield return new WaitForSeconds(timeToWait);
        targetRotation = Quaternion.Euler(0, 0, 0);
    }

    void PlayerHP2BossBehaviour(ref bool hasRotated)
    {
        targetPosition = pos2GO.transform.position;
        targetScale = new Vector3(1.75f, 1.75f, 1.75f);
        if (!hasRotated2)
        {
            hasRotated2 = true;
            targetRotation = Quaternion.Euler(0, 0, 25f);
            StartCoroutine(BossTimer());
        }
    }

    void PlayerHP1BossBehaviour(ref bool hasRotated)
    {
        targetPosition = pos3GO.transform.position;
        targetScale = new Vector3(2, 2, 2);
        if (!hasRotated1)
        {
            hasRotated1 = true;
            targetRotation = Quaternion.Euler(0, 0, -25);
            StartCoroutine(BossTimer());
        }
    }
}