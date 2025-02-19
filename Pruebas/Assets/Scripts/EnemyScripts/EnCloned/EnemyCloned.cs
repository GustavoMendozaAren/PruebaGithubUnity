using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloned : MonoBehaviour
{
    private GameObject player;
    //private Rigidbody myBody;
    private Animator anim;

    private float enemy_Speed = 4f;
    private float enemy_Speed2 = 2f;

    private float enemy_Watch_Treshgold = 40f;
    private float enemy_Attack_Treshold = 6f;

    public Transform waypoint1;

    public GameObject damagePoint;


    void Awake()
    {


        player = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG);
        //myBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        EnemyAI();
    }

    void EnemyAI()
    {

        Vector3 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;
        direction.Normalize();

        var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        var targetRotationWayPoint = Quaternion.LookRotation(waypoint1.transform.position - transform.position);

        Vector3 velocity = direction * enemy_Speed;

        if (distance > enemy_Attack_Treshold && distance < enemy_Watch_Treshgold)
        {

            //myBody.velocity = new Vector3(velocity.x, velocity.y, velocity.z);
            var step = enemy_Speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

            anim.SetTrigger(MyTags.SWIM_TRIGGER);

            //transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, enemy_Speed2 * Time.deltaTime);

        }
        else if (distance < enemy_Attack_Treshold)
        {
            //myBody.velocity = new Vector3(velocity.x, velocity.y, velocity.z);
            var step = enemy_Speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

            anim.SetTrigger(MyTags.ATTACK_TRIGGER);

            //transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z));

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, enemy_Speed2 * Time.deltaTime);

        }
        else
        {

            var step = enemy_Speed2 * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, waypoint1.transform.position, step);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationWayPoint, enemy_Speed2 * Time.deltaTime);


        }

    }

    void ActivateDamagePoint()
    {
        damagePoint.SetActive(true);
    }

    void DeactivateDamagePoint()
    {
        damagePoint.SetActive(false);
    }
}
