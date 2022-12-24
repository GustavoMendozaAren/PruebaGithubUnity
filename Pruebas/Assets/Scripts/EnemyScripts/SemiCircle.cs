using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiCircle : MonoBehaviour
{
    float counter1 = 0f;
    float counterx = 0f;
    bool sh = false;

    Rigidbody mRigid;

    private void Awake()
    {
        mRigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!sh)
        {
            Movement_2();
        }

        if (sh)
        {
            Movement_3();
        }

        if (Input.GetKeyDown(KeyCode.B)&&!sh)
        {
            
            sh = true;
        }else if (Input.GetKeyDown(KeyCode.B) && sh)
        {
            
            sh = false;
        }
    }

    void Movement_2()
    {
        counter1 += Time.deltaTime;

        float x1 = transform.position.x;
        float y1 = transform.position.y;
        float z1 = counter1;

        transform.position = new Vector3(x1, y1, z1);
    }
    void Movement_3()
    {
        counterx += Time.deltaTime;

        float x1 = counterx;
        float y1 = transform.position.y;
        float z1 = transform.position.z;

        transform.position = new Vector3(x1, y1, z1);
    }
}
