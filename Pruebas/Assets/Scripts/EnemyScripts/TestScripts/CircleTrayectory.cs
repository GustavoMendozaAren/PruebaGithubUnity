using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTrayectory : MonoBehaviour
{
    float counter = 0f;

    void Update()
    {
        Movement_1();
    }

    void Movement_1()
    {
        counter += Time.deltaTime * 2f;

        float x = 0;
        float y = 5;
        float z = 15 + counter;

        transform.position = new Vector3(x, y, z);

    }
}
