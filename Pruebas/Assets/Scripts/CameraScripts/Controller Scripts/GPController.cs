using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPController : MonoBehaviour
{

    public static bool GamePaused = false;

   

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GamePaused)
            {
                Time.timeScale = 1;
                GamePaused = false;
            }
            else
            {
                Time.timeScale = 0;
                GamePaused = true;
            }
        }

        

    }
}
