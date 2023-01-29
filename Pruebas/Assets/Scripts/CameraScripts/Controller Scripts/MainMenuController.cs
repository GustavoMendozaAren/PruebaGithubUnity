using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public GameObject CreditsMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        //Debug.Log("The cursor entered the selectable UI element.");
    }

    public void CreditsM()
    {
        CreditsMenu.SetActive(true);
    }

    public void ReturnMenu()
    {
        CreditsMenu.SetActive(false);
    }
}
