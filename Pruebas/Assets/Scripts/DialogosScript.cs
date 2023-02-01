using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogosScript : MonoBehaviour
{

    public GameObject Tuto1;
    public GameObject Tuto2;
    public GameObject Tuto3;
    public GameObject Tuto4;
    private void Start()
    {
        Invoke("Tut1", 1f);
        Invoke("Tut2", 3f);
        Invoke("Tut3", 6f);
        Invoke("Tut4", 9f);
    }

    public void Tut1()
    {
        Tuto1.SetActive(true);
    }

    public void Tut2()
    {
        Tuto2.SetActive(true);
    }

    public void Tut3()
    {
        Tuto3.SetActive(true);
    }

    public void Tut4()
    {
        Tuto4.SetActive(true);
    }

}
