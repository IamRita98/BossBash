using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtZone : MonoBehaviour
{
    public int playerHP = 3;
    
    SoundManager soundManager;
    PauseMenu pMenu;

    private void Start()
    {
        pMenu = GameObject.Find("Canvas").GetComponent<PauseMenu>();
        soundManager = GameObject.Find("Sound Manager")?.GetComponent<SoundManager>();
    }
    
    private void Update()
    {
        if (playerHP <= 0)
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
        playerHP--;
        soundManager.OnDamageSFX();
    }
}
