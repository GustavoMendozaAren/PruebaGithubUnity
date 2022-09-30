using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject PauseMenuUI;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GamePaused)
            {

                Resume();
                
            }
            else
            {

                Pause();
                
            }
        }



    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GamePaused = false;

    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GamePaused = true;

    }

    public void Menu()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");

    }


}
