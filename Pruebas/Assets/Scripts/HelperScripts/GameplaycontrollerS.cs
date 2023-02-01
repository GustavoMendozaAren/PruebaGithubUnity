using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplaycontrollerS : MonoBehaviour
{

    public static GameplaycontrollerS instance;

    public GameObject DeadPanel;
    public GameObject WonPanel;

    public GameObject enemy;
    public GameObject fpoint;

    public Animator WeaponsText;
    public Animator WeaponsText2;
    public Animator SwitchWeapons;

    public GameObject WeponsT;

    public GameObject UsaETt;

    float contador = 0f;

    //wwwwwwwwwwwwwwwwwwwwwwwwwwwpublic BulletProjectile Dmg;


    [HideInInspector]
    public bool isPlayerAlive;

    [HideInInspector]
    public bool Weapon1 = false;

    private bool Ciclo = false;
    private bool CambioDeArma = false;

    public bool ClickDV = false;

    private void Awake()
    {
        MakeInstance();
    }


    void Start()
    {
        isPlayerAlive = true;

        Invoke("ActiveEnemy", 3f);

        //WeponsT = GetComponent<Animation>();
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
            return;
        }
    }

    public void GameOver()
    {
            Time.timeScale = 0f;
            DeadPanel.SetActive(true);
            ClickDV = true;
    }


    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameplay");

        FindObjectOfType<AudioManagerG>().Play2("Click");
        
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");

        FindObjectOfType<AudioManagerG>().Play2("Click");
    }

    public void GameWon()
    {
        Time.timeScale = 0f;
        WonPanel.SetActive(true);
        ClickDV = true;

    }

    void WeaponChange()
    {
        if (CambioDeArma)
        {

            if (Input.GetKeyDown(KeyCode.E) && !Ciclo)
            {
                //print("W1");
                Weapon1 = false;
                WeaponsText.Play("Weapon1Fade");
                Ciclo = true;

                //Dmg.damageAmount = 5;

                FindObjectOfType<AudioManagerG>().Play2("Click");
            }
            else if (Input.GetKeyDown(KeyCode.E) && Ciclo)
            {
                //print("W2");
                Weapon1 = true;
                WeaponsText2.Play("Weapon2Fade");
                Ciclo = false;

                //Dmg.damageAmount = 10;

                FindObjectOfType<AudioManagerG>().Play2("Click");
            }

        }
    }

    public void WeaponCollected()
    {
        CambioDeArma = true;
        //SwitchWeapons.Play("CambioDeAramaFade");
        UsaETt.SetActive(true);

        WeponsT.SetActive(true);

    }

    void ActiveEnemy()
    {
        enemy.gameObject.SetActive(true);
        fpoint.gameObject.SetActive(true);
    }
}
