using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioSource aSource;
    public AudioClip menuSong;
    public AudioClip battleSong;
    AudioClip currentSong;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1)
        {
            if(currentSong != menuSong)
            {
                currentSong = menuSong;
                aSource.clip = menuSong;
                aSource.Play();
            }
        }
        else
        {
            if(currentSong != battleSong)
            {
                currentSong = battleSong;
                aSource.clip = battleSong;
                aSource.Play();
            }
        }
    }
}
