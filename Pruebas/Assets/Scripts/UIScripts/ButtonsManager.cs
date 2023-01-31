using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public GameObject BuzoImagen;
    public GameObject BuzoDescripcion;
    public GameObject PanelJinetes;
    public GameObject PanelBaracuda;
    public GameObject Loadcanvas;
    public GameObject[] Char;
    public int selectChar;

    bool Ventana = false;

    public void Guardar()
    {
        StartCoroutine(GuardarCoo());
    }

    IEnumerator GuardarCoo()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Gameplay");

        Loadcanvas.SetActive(true);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Loadcanvas.SetActive(false);
    }

    public void Jinetes()
    {
        Ventana = true;
        PanelBaracuda.SetActive(false);
        PanelJinetes.SetActive(true);
    }

    public void Monturas()
    {
        Ventana = false;
        PanelBaracuda.SetActive(true);
        PanelJinetes.SetActive(false);
    }

    /*public void DerChar()
    {
        contador += contador + 1;
    }*/

    /*public void IzqChar()
    {
        contador -= contador - 1;
    }*/
    
    public void NextChar()
    {
        Char[selectChar].SetActive(false);
        selectChar = (selectChar + 1) % Char.Length;
        Char[selectChar].SetActive(true);
        if (selectChar == 2)
        {
            BuzoImagen.SetActive(true);
            BuzoDescripcion.SetActive(true);
        }
        else
        {
            BuzoImagen.SetActive(false);
            BuzoDescripcion.SetActive(false);
        }
    }

    public void PrevChar()
    {
        Char[selectChar].SetActive(false);
        selectChar--;
        if (selectChar < 0)
        {
            selectChar += Char.Length;
        }
        Char[selectChar].SetActive(true);
    }
}
