using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AimScript : MonoBehaviour
{

    private Rigidbody myBody;

    private Animator anim;
    //private bool isPlayerMoving;

    public float playerSpeed = 0.1f;
    public float rotationSpeed = 8f;

    private float moveVertical;

    private float rotY, rotX, showtime = 0;

    public LayerMask aimColliderLayerMask = new LayerMask();
    //public Transform debugTransform;
    public Transform pfBulletProjectile;
    public Transform spawnBulletPosition;
    //public Transform VfxBoom;

   

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        anim.speed = 0f;
        moveVertical = 0f;
        rotY = transform.localRotation.eulerAngles.y;
        rotX = transform.localRotation.eulerAngles.x;
    }


    void Update()
    {
        PlayerMoveKeyboard();
        Attack();
        //AnimatePlayer();
        RingAction();

        //-------------------------------------------------

        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if ( Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            //debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
            Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));


        }

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
            anim.speed = 3.5f;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            moveVertical = 0.1f;
            anim.speed = 1f;
        }
    }

    void MoveAndRotate()
    {
        if (moveVertical != 0)
        {
            //myBody.MovePosition(transform.position + transform.forward * (moveVertical * playerSpeed));
            transform.position += transform.forward * (moveVertical * playerSpeed);
        }

        rotX -= rotationSpeed * Input.GetAxis("Mouse Y");
        rotY += rotationSpeed * Input.GetAxis("Mouse X");

        //transform.eulerAngles = new Vector3(rotX, rotY, 0f);

        //rotX += moveUp * rotationSpeed;
        //rotY += moveHorizontal * rotationSpeed;
        transform.rotation = Quaternion.Euler(rotX, rotY, 0f);


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
            //Instantiate(VfxBoom, (transform.position), Quaternion.identity);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ring"))
        {

            Debug.Log("Enter");
            showtime = 2;
            other.gameObject.SetActive(false);
        }
    }

    void RingAction()
    {
        if (showtime > 0)
        {
            showtime -= Time.deltaTime;
            //Debug.Log("TimerStart");
            moveVertical = 3f;
            anim.speed = 7f;
        }
        if (showtime < 0)
        {
            showtime = 0;
            //Debug.Log("Timesup");
            moveVertical = 0.1f;
            anim.speed = 1f;
        }
        
    }

}
