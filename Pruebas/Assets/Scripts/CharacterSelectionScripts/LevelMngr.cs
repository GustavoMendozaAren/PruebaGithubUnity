using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMngr : MonoBehaviour

{

    [SerializeField] private GameObject LoaderCanvas;

    public static LevelMngr Instance2;

    void Awake()
    {
        if (Instance2 == null)
        {
            Instance2 = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance2 != null)
        {
            Destroy(gameObject);
        }
    }

    public async void LoadScene(string Gameplay)
    {
        var scene = SceneManager.LoadSceneAsync("Gameplay");

        scene.allowSceneActivation = false;

        LoaderCanvas.SetActive(true);

        /*do
        {
            
        } while (scene.progress < 09f);*/

        scene.allowSceneActivation = true;

        LoaderCanvas.SetActive(false);

    }
}
