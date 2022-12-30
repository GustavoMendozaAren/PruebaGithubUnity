using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidScript : MonoBehaviour
{

    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        AnimatePlayer();
    }

    void AnimatePlayer()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {

            if (!anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.CLAP_ANIMATION))
            {
                anim.SetTrigger(MyTags.CLAP_TRIGGER);
                FindObjectOfType<AudioManagerG>().Play2("Claps");
            }

            

        }
    }

    }
