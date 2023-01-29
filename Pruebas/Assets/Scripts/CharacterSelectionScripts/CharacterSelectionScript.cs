using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionScript : MonoBehaviour
{
    public GameObject[] characters;
    public GameObject[] text;
    public int selectedCharacter = 0;
    public int selectedText = 0;
    //public static int selectedCharacter = 0;

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);

        text[selectedText].SetActive(false);
        selectedText = (selectedText + 1) % text.Length;
        text[selectedText].SetActive(true);
    }

    public void PreviousCharacter()
    {

        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter<0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);

        text[selectedText].SetActive(false);
        selectedText--;
        if (selectedText < 0)
        {
            selectedText += text.Length;
        }
        text[selectedText].SetActive(true);

    }
    
    public void StartGame2()
    {

        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(2, LoadSceneMode.Single);
        //LevelMngr.Instance2.LoadScene("Gameplay");
       
    }

}
