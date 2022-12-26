using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplaycontrollerS : MonoBehaviour
{

    public static GameplaycontrollerS instance;

    public GameObject DeadPanel;

    [HideInInspector]
    public bool isPlayerAlive;

    private void Awake()
    {
        MakeInstance();
    }


    void Start()
    {
        isPlayerAlive = true;
    }


    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        DeadPanel.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2, LoadSceneMode.Single);

    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
