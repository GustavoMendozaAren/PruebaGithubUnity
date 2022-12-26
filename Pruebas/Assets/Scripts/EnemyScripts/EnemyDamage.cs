using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public int damageAmount = 2;
    public LayerMask playerLayer;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().ApplyDamage(damageAmount);
            print("Hit");
        }
    }

    /*void Update()
    {

        Collider[] hits = Physics.OverlapSphere(transform.position, 0.1f, playerLayer);

        if (hits.Length > 0)
        {
            if (hits [0].CompareTag("Player"))
            {
                hits[0].gameObject.GetComponent<PlayerHealth>().ApplyDamage(damageAmount);
                print("Hit");

            }
        }

    }*/
}
