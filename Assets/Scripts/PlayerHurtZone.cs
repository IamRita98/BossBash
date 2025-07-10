using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtZone : MonoBehaviour
{
    public int playerHP = 3;
    
    SoundManager soundManager;
    PauseMenu pMenu;

    public GameObject typeWriter1;
    public GameObject typeWriter2;
    public GameObject typeWriter3;
    public GameObject you;
    public GameObject are;
    public GameObject fired;

    private void Start()
    {
        pMenu = GameObject.Find("Canvas").GetComponent<PauseMenu>();
        soundManager = GameObject.Find("Sound Manager")?.GetComponent<SoundManager>();
    }

    private void Update()
    {
        if (playerHP < 0)
        {
            pMenu.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //This will check the Collider 2D of the GO this script is attached to
    {
        if (!collision.CompareTag("Words")) //If the object collided w/ has the tag "Words" (This can be a placeholder tag, we just need to it match whatever tag the words will have when moving)
        {
            return;
        }
        Destroy(collision);
    }

    public void DamageTaken()
    {
        playerHP--;
        soundManager.OnDamageSFX();
        switch (playerHP)
        {
            case 2:
                typeWriter1.SetActive(false);
                you.SetActive(true);
                break;
            case 1:
                typeWriter2.SetActive(false);
                are.SetActive(true);
                break;
            case 0:
                typeWriter3.SetActive(false);
                fired.SetActive(true);
                pMenu.GameOver();
                break;
        }
    }
}
