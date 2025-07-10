using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnHoverSFX : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource onHoverSFX;
    Button btn;
    public AudioSource onClickSFX;
    SoundManager soundManager;
    public void Start()
    {
        btn = GetComponent<Button>();
        /*        if (gameObject.CompareTag("Start Button"))
                {

                }
                else
                {
                    btn.onClick.AddListener(ClickSFX);
                }*/
        btn.onClick.AddListener(StartClickSFX);
        soundManager = GameObject.FindGameObjectWithTag("Sound Manager").GetComponent<SoundManager>();
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        soundManager.BtnHoverSFX();
    }
    /*    public void ClickSFX()
        {
            soundManager.BtnClickSFX();
        }*/// Removed button on click sound. May return. Mouse click making keyboard sounds funnier.
    public void StartClickSFX()
    {
        soundManager.StartBtnClickSFX();
    }
}
