using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplaycontrollerS : MonoBehaviour
{

    public static GameplaycontrollerS instance;

    public GameObject DeadPanel;

    public Animator WeaponsText;
    public Animator WeaponsText2;

    [HideInInspector]
    public bool isPlayerAlive;

    [HideInInspector]
    public bool Weapon1 = false;

    private void Awake()
    {
        MakeInstance();
    }


    void Start()
    {
        isPlayerAlive = true;
    }
    private void Update()
    {
        WeaponChange();
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

    void WeaponChange()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("W1");
            Weapon1 = false;
            WeaponsText.Play("Weapon1Fade");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            print("W2");
            Weapon1 = true;
            WeaponsText2.Play("Weapon2Fade");
        }
    }
}
