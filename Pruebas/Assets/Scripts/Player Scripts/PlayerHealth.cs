using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health = 10;

    public GameObject DeadPanel;



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
            Time.timeScale = 0f;
            DeadPanel.SetActive(true);
            health = 4;

        }


    }




}
