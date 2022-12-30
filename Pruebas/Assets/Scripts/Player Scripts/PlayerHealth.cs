using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health = 10;
    private AimScript playerScript;

    public PlayerHealthBar playerHealthBar;
    public int currentHealth;

    private void Awake()
    {
        playerScript = GetComponent<AimScript>();
    }

    private void Start()
    {
        currentHealth = health;
        playerHealthBar.MaxHealth(currentHealth);
    }
    public void ApplyDamage(int damageAmaount)
    {

        health -= damageAmaount;

        playerHealthBar.SetHealth(health);

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
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("WeaponDrop"))
        {
            other.gameObject.SetActive(false);
            GameplaycontrollerS.instance.WeaponCollected();
        }
    }




}
