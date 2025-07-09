using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    AudioSource aSource;
    public AudioClip onHoverSFX;
    public AudioClip onClickSFX;
    public AudioClip onWordCompleteSFX;
    public AudioClip onLevelCompleteSFX;
    public AudioClip onStartBtnClickSFX;
    public List<AudioClip> onTypingSFX;
    public List<AudioClip> onDamageSFX;
    public List<AudioClip> onBossSpeakSFX;
    public bool playDamageSFX;
    public bool playWordCompletionSFX;
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void Start()
    {
        aSource = GetComponent<AudioSource>();
        TypingInput.OnWordCompleted += WordCompletionSFX;
        TypingInput.OnLevelCompleted += LevelCompletionSFX;
    }
    public void Update()
    {
        if (playDamageSFX)
        {
            playDamageSFX = false;
            OnDamageSFX();
        }
        if (Input.anyKeyDown)
        {
            OnTypingSFX();
        }
    }
    void WordCompletionSFX(TypingEventPayload completedWord)
    {
        aSource.clip = onWordCompleteSFX;
        aSource.Play();
    }
    void LevelCompletionSFX(string scenarioName)
    {
        aSource.clip = onLevelCompleteSFX;
        aSource.Play();
    }
    public void BtnHoverSFX()
    {
        aSource.clip = onHoverSFX;
        aSource.PlayOneShot(onHoverSFX);
    }
    public void BtnClickSFX()
    {
        aSource.clip = onClickSFX;
        aSource.Play();
    }
    public void OnDamageSFX()
    {
        aSource.clip = onDamageSFX[Random.Range(0, 2)];
        aSource.Play();
    }

    public void OnTypingSFX()
    {
        aSource.PlayOneShot(onTypingSFX[Random.Range(0, 10)]);
    }
    public void StartBtnClickSFX()
    {
        aSource.clip = onStartBtnClickSFX;
        aSource.Play();
    }
    //Make sure to add button hover to pause menu buttons!
    public void OnBossSpeakingSFX()
    {
        aSource.clip = onBossSpeakSFX[Random.Range(0, 5)];
        aSource.Play();
    }
}
