using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public GameObject CreditsMenu;
    public GameObject OptionsPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        //Debug.Log("The cursor entered the selectable UI element.");

        FindObjectOfType<AudioManagerG>().Play2("Click");
    }

    public void CreditsM()
    {
        CreditsMenu.SetActive(true);

        FindObjectOfType<AudioManagerG>().Play2("Click");
    }

    public void ReturnMenu()
    {
        CreditsMenu.SetActive(false);

        FindObjectOfType<AudioManagerG>().Play2("Click");
    }

    public void Optionsmenu()
    {
        OptionsPanel.SetActive(true);

        FindObjectOfType<AudioManagerG>().Play2("Click");
    }

    public void BackButton()
    {
        OptionsPanel.SetActive(false);

        FindObjectOfType<AudioManagerG>().Play2("Click");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
