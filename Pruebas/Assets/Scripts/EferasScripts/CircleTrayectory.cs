using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTrayectory : MonoBehaviour
{
    float counter = 0f;

    float x = 0f, y = 0f, z = 25f;

    bool ciclo = false;

    void Update()
    {
        Movement_1();
    }

    void Movement_1()
    {
        if (z <= 25f)
        {
            ciclo = false;
            counter = 0;
        }
        if(!ciclo)
        {
            counter += Time.deltaTime * 5f;

            x = -0.5f;
            y = 5f;
            z = 25f + counter;

            transform.position = new Vector3(x, y, z);
        }
        if (z >= 110f)
        {
            ciclo = true;
            counter = 0;
        }
        if (ciclo)
        {
            counter += Time.deltaTime * 5f;

            x = -0.5f;
            y = 5f;
            z = 110f - counter;

            transform.position = new Vector3(x, y, z);
        }
    }
}
