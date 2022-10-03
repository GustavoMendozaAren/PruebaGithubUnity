using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorCharacterScript : MonoBehaviour
{
    
    void Update()
    {
        transform.Rotate(0f, 50 * Time.deltaTime, 0f, Space.Self);
    }
}
