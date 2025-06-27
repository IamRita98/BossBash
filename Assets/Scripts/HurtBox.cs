using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public int playerHP = 3;

    private void Update()
    {
        if(playerHP <= 0)
        {
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Words"))
        {
            return;
        }
        Destroy(collision);
        playerHP--;
    }

    private void GameOver()
    {
        //Prob fade screen & music then load back into Main menu not sure how we want to do this yet.
        //Or we could bring up an edited pause menu w/ just retry/return to menu
    }
}
