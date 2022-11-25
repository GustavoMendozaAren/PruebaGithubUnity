using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingScript : MonoBehaviour
{

    float ActiveTime = -1;
    void Update()
    {

        
        if (gameObject.activeSelf)
        {
            Debug.Log("Hola");
            
        }
        else
        {
            Debug.Log("Adios");
            ActiveTime = 5;
            if (ActiveTime > 0)
            {
                ActiveTime -= Time.deltaTime;
            }
            if (ActiveTime < 0)
            {
                ActiveTime = 0;
                gameObject.SetActive(true);
            }
        }
        
            
        

    }
}
