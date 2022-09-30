using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{

    private Rigidbody myBody;

    private Animator anim;
    //private bool isPlayerMoving;

    public float playerSpeed = 0.2f;
    public float rotationSpeed = 12f;

    private float moveHorizontal, moveVertical, moveUp;

    private float rotY, rotX;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        moveVertical = 0;
        rotY = transform.localRotation.eulerAngles.y;
        rotX = transform.localRotation.eulerAngles.x;
    }


    void Update()
    {
        PlayerMoveKeyboard();
        Attack();
        //AnimatePlayer();
    }

    void FixedUpdate()
    {
        MoveAndRotate();
    }

    void PlayerMoveKeyboard()
    {
      

        if (Input.GetKeyDown(KeyCode.W))
        {
            moveVertical = 1;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            moveVertical = 0;
        }
    }

    void MoveAndRotate()
    {
        if (moveVertical != 0)
        {
            myBody.MovePosition(transform.position + transform.forward * (moveVertical * playerSpeed));
        }

        rotX -= rotationSpeed * Input.GetAxis("Mouse Y");
        rotY += rotationSpeed * Input.GetAxis("Mouse X");

        //transform.eulerAngles = new Vector3(rotX, rotY, 0f);

        //rotX += moveUp * rotationSpeed;
        //rotY += moveHorizontal * rotationSpeed;
        myBody.rotation = Quaternion.Euler(rotX, rotY, 0f);


    }

    /*void AnimatePlayer()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {

            if (!anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.CLAP_ANIMATION))
            {
                anim.SetTrigger(MyTags.CLAP_TRIGGER);
            }

        }
         if (moveVertical != 0)
         {
             if (!isPlayerMoving)
             {
                 if (!anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.WALK_ANIMATION))
                 {
                     isPlayerMoving = true;
                     anim.SetTrigger(MyTags.WALK_TRIGGER);
                 }
             }

         }
         else
         {
             if (isPlayerMoving)
             {
                 if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.WALK_ANIMATION))
                 {
                     isPlayerMoving = false;
                     anim.SetTrigger(MyTags.STOP_TRIGGER);
                 }
             }
         }
    }*/

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            if (!anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_ANIMATION))
            {
                anim.SetTrigger(MyTags.ATTACK_TRIGGER);
            }

        }
    }

}
