using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{

    private Rigidbody bulletRigidbody;
    public Transform VfxHitAnother;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 50f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider another)
    {

        if (another.GetComponent<BulletTarget>() != null)
        {
            //Hit target
        } else
        {
            //Hit something else
            Instantiate(VfxHitAnother, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    

}
