using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int health = 20;
    public int currentHealth;

    private EnemyScript enemyScript;
    private Animator anim;

    public Transform DeadExplosion;

    public HealthBar healthBar;

    void Awake()
    {
        enemyScript = GetComponent<EnemyScript>();
        anim = GetComponent<Animator>();
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
            enemyScript.enabled = false;

            anim.enabled = false;
            Invoke("DeactivateEnemy", 2f);
        }

    }

    void DeactivateEnemy()
    {
        Instantiate(DeadExplosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
