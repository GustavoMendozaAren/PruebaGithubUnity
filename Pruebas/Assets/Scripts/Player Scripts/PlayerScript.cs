using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody myBody;

    private Animator anim;
    private bool isPlayerMoving;

    public float playerSpeed = 0.2f;
    public float rotationSpeed = 4f;

    private float moveHorizontal, moveVertical, moveUp;

    private float rotY = 0f, rotX = 0f;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        moveVertical = 1;
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
        if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            moveHorizontal = -1;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            moveHorizontal = 0;
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveHorizontal = 1;
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            moveHorizontal = 0;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
             moveUp = -1;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            moveUp = 0;
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveUp = 1;
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            moveUp = 0;
        }

        /*if (Input.GetMouseButtonDown(0))
        {
            moveVertical = 1;
        }
        if(Input.GetMouseButtonUp(0))
        {
            moveVertical = 0;
        }*/
    }

    void MoveAndRotate()
    {
        if (moveVertical != 0)
        {
            myBody.MovePosition(transform.position + transform.forward * (moveVertical * playerSpeed));
        }

        rotX += moveUp * rotationSpeed;
        rotY += moveHorizontal * rotationSpeed;
        myBody.rotation = Quaternion.Euler(rotX, rotY, 0f);


    }

    /*void AnimatePlayer()
    {
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
