using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsBlZ1 : MonoBehaviour
{
    float counter = 0f;

    void Update()
    {
        Movement_1();
    }

    void Movement_1()
    {
        counter += Time.deltaTime * .2f;

        float x = 4.5f - (18f * Mathf.Cos(counter));
        float y = 5f;
        float z = -7f + (18f * Mathf.Sin(counter));

        transform.position = new Vector3(x, y, z);

    }
}
