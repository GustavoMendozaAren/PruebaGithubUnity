using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health = 10;
    private AimScript playerScript;

    public PlayerHealthBar playerhealthBar;
    public int currentHealth;

    private void Awake()
    {
        playerScript = GetComponent<AimScript>();
        //GameplaycontrollerS.instance.isPlayerAlive = true;

    }

    private void Start()
    {
        Healthfunction();
    }

    public void Healthfunction()
    {
        currentHealth = health;
        playerhealthBar.MaxHealth(currentHealth);
    }
    public void ApplyDamage(int damageAmaount)
    {

        health -= damageAmaount;

        playerhealthBar.SetHealth(health);

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

            //GameplaycontrollerS.instance.isPlayerAlive = false;

            GameplaycontrollerS.instance.GameOver();
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("WeaponDrop"))
        {
            other.gameObject.SetActive(false);
            GameplaycontrollerS.instance.WeaponCollected();



            FindObjectOfType<AudioManagerG>().Play2("Suspiro");
        }
    }




}
