using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public GameObject IncognitoImage;
    public GameObject IncogBar;
    public GameObject BuzoImagen;
    public GameObject BuzoDescripcion;
    public GameObject BarracudaImagen;
    public GameObject BarracudaInfo;
    public GameObject PanelJinetes;
    public GameObject PanelBaracuda;
    public GameObject Loadcanvas;
    public GameObject[] Char;
    public GameObject[] Char2;
    public int selectChar;
    public int selectChar2;

    int a = 1;
    bool clave1 = false, clave2 = false;

    public void Guardar()
    { 
        if ( clave1 == true && clave2 == true)
        {
            StartCoroutine(GuardarCoo());
            
        }
        FindObjectOfType<AudioManagerG>().Play2("Click");


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
        a = 2;
        PanelBaracuda.SetActive(false);
        PanelJinetes.SetActive(true);
        FindObjectOfType<AudioManagerG>().Play2("Click");
    }

    public void Monturas()
    {
        a = 3;
        PanelBaracuda.SetActive(true);
        PanelJinetes.SetActive(false);
        FindObjectOfType<AudioManagerG>().Play2("Click");
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
        if (a == 2)
        {

            Char[selectChar].SetActive(false);
            selectChar = (selectChar + 1) % Char.Length;
            Char[selectChar].SetActive(true);
            if (selectChar == 2)
            {
                BuzoImagen.SetActive(true);
                BuzoDescripcion.SetActive(true);
                clave1 = true;
            }
            else if(selectChar == 0 || selectChar == 1)
            {
                IncognitoImage.SetActive(false);
                BuzoImagen.SetActive(false);
                BuzoDescripcion.SetActive(false);
                clave1 = false;
            }else
            {
                IncognitoImage.SetActive(true);
                BuzoImagen.SetActive(false);
                BuzoDescripcion.SetActive(false);
                clave1 = false;
            }

        }else if (a == 3)
        {
            Char2[selectChar2].SetActive(false);
            selectChar2 = (selectChar2 + 1) % Char2.Length;
            Char2[selectChar2].SetActive(true);
            if (selectChar2 == 2)
            {
                BarracudaImagen.SetActive(true);
                BarracudaInfo.SetActive(true);
                clave2 = true;
            }
            else if (selectChar2 == 0 || selectChar2 == 1 )
            {
                IncogBar.SetActive(false);
                BarracudaImagen.SetActive(false);
                BarracudaInfo.SetActive(false);
                clave2 = false;
            }
            else
            {
                IncogBar.SetActive(true);
                BarracudaImagen.SetActive(false);
                BarracudaInfo.SetActive(false);
                clave2 = false;
            }
        }
        FindObjectOfType<AudioManagerG>().Play2("Click");
    }

    public void PrevChar()
    {
        if (a == 2)
        {

            Char[selectChar].SetActive(false);
            selectChar--;
            if (selectChar < 0)
            {
                selectChar += Char.Length;
            }
            Char[selectChar].SetActive(true);
            if (selectChar == 2)
            {
                IncognitoImage.SetActive(false);
                BuzoImagen.SetActive(true);
                BuzoDescripcion.SetActive(true);
                clave1 = true;
            }
            else if(selectChar == 0 || selectChar == 1)
            {
                IncognitoImage.SetActive(false);
                BuzoImagen.SetActive(false);
                BuzoDescripcion.SetActive(false);
                clave1 = false;
            }else
            {
                IncognitoImage.SetActive(true);
                BuzoImagen.SetActive(false);
                BuzoDescripcion.SetActive(false);
                clave1 = false;
            }

        }
        else if (a == 3)
        {
            Char2[selectChar2].SetActive(false);
            selectChar2--;
            if (selectChar2 < 0)
            {
                selectChar2 += Char2.Length;
            }
            Char2[selectChar2].SetActive(true);
            if (selectChar2 == 2)
            {
                IncogBar.SetActive(false);
                BarracudaImagen.SetActive(true);
                BarracudaInfo.SetActive(true);
                clave2 = true;
            }
            else if(selectChar2 == 0 || selectChar2 == 1)
            {
                IncogBar.SetActive(false);
                BarracudaImagen.SetActive(false);
                BarracudaInfo.SetActive(false);
                clave2 = false;
            }
            else
            {
                IncogBar.SetActive(true);
                BarracudaImagen.SetActive(false);
                BarracudaInfo.SetActive(false);
                clave2 = false;
            }

        }
        FindObjectOfType<AudioManagerG>().Play2("Click");
    }
}
