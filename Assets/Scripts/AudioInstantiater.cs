using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInstantiater : MonoBehaviour
{
    public GameObject musicManagerGO;
    public GameObject sfxManagerGO;

    private void Awake()
    {
        if(!GameObject.Find("Music Manager"))
        {

            GameObject musicManager = Instantiate(musicManagerGO);
            musicManager.name = "Music Manager";
        }
        if(!GameObject.Find("Sound Manager"))
        {
            GameObject soundManager = Instantiate(sfxManagerGO);
            soundManager.name = "Sound Manager";
        }
    }
}
