using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private GameObject player;
    private Rigidbody myBody;
    private Animator anim;

    private float enemy_Speed = 5f;

    private float enemy_Watch_Treshgold = 70f;
    private float enemy_Attack_Treshold = 6f;

    void Awake()
    {

        player = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG);
        myBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        EnemyAI () ;
    }

    void EnemyAI ()
    {

        Vector3 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;
        direction.Normalize();

        Vector3 velocity = direction * enemy_Speed;
        
        if (distance > enemy_Attack_Treshold && distance < enemy_Watch_Treshgold)
        {
            
            myBody.velocity = new Vector3(velocity.x, velocity.y, velocity.z);

            if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_ANIMATION)) {
                anim.SetTrigger(MyTags.STOP_TRIGGER);
            }

            anim.SetTrigger(MyTags.SWIM_TRIGGER);

            transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z));

        } else if (distance < enemy_Attack_Treshold)
        {

            if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.SWIM_ANIMATION))
            {
                anim.SetTrigger(MyTags.STOP_TRIGGER);
            }

            anim.SetTrigger(MyTags.ATTACK_TRIGGER);

            transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z));
        } else
        {

            myBody.velocity = new Vector3(0f, 0f, 0f);

            if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.SWIM_ANIMATION) || anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_ANIMATION))
            {

                anim.SetTrigger(MyTags.STOP_TRIGGER);

            }

        }
    }
}
