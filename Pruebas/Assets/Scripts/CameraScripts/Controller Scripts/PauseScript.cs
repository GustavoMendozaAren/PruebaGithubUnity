using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject PauseMenuUI;
    public GameObject DeadPanel2;

    private AimScript PlayerScr;

    private void Awake()
    {
        PlayerScr = GetComponent<AimScript>();
    }

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

        FindObjectOfType<AudioManagerG>().Play2("Click");

        PlayerScr.enabled = true;

    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GamePaused = true;

        FindObjectOfType<AudioManagerG>().Play2("Click");

        PlayerScr.enabled = false;

    }

    public void Menu()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");

        FindObjectOfType<AudioManagerG>().Play2("Click");

    }



}
