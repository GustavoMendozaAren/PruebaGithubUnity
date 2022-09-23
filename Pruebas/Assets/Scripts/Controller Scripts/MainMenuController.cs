using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
        //Debug.Log("The cursor entered the selectable UI element.");
    }
}
