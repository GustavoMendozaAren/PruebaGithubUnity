using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPointCloned : MonoBehaviour
{
    float counter = 0f;

    void Update()
    {
        Movement_1();
    }

    void Movement_1()
    {
        counter += Time.deltaTime * .14f;

        float x = 15 * Mathf.Cos(counter);
        float y = 5;
        float z = 65 + (15 * Mathf.Sin(counter));

        transform.position = new Vector3(x, y, z);

    }
}
