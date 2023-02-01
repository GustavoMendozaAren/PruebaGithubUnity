using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogosScript : MonoBehaviour
{

    public GameObject Tuto1;
    public GameObject Tuto2;
    private void Start()
    {
        Invoke("Tut1", 1f);
        Invoke("Tut2", 3f);
    }

    public void Tut1()
    {
        Tuto1.SetActive(true);
    }

    public void Tut2()
    {
        Tuto2.SetActive(true);
    }

}
