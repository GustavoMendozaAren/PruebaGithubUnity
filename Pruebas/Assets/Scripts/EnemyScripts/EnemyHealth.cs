using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    

    public int health = 20;
    public int currentHealth;

    private EnemyScript enemyScript;
    private Animator anim;
    private Rigidbody myBody;
    

    public Transform DeadExplosion;
    //public Transform DeadSymbol;

    public HealthBar healthBar;

    void Awake()
    {
        enemyScript = GetComponent<EnemyScript>();
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        currentHealth = health;
        healthBar.MaxHealth(currentHealth);
    }

    public void ApplyDamage (int damageAmount)
    {
        
        
        health -= damageAmount;

        healthBar.SetHealth(health);
            
        

        if (health < 0)
        {
            health = 0;
            
        }
        if (health == 0)
        {
            myBody.detectCollisions = false;

            enemyScript.enabled = false;
            anim.enabled = false;
            //Invoke("DeactivateEnemy", 2f);
            DeactivateEnemy();
            //Vector3 Hola = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
            //Instantiate(DeadSymbol, Hola, Quaternion.identity);
            GameplaycontrollerS.instance.GameWon();
            
        }

    }

    void DeactivateEnemy()
    {
        
        Instantiate(DeadExplosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
