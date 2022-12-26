using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health = 10;
    private AimScript playerScript;

    private void Awake()
    {
        playerScript = GetComponent<AimScript>();
    }
    public void ApplyDamage(int damageAmaount)
    {

        health -= damageAmaount;

        if (health < 0)
        {
            health = 0;
        }

        //Display health value

        if (health == 0)
        {
            playerScript.enabled = false;
            //DeadPanel.SetActive(true);
            //Time.timeScale = 0f;

            GameplaycontrollerS.instance.isPlayerAlive = false;

            //GameOver Panel
            GameplaycontrollerS.instance.GameOver();
        }


    }




}
