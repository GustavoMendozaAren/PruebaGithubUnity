using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverOn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public RectTransform PlayButton;

    // Start is called before the first frame update
    void Start()
    {
        PlayButton.GetComponent<Animator>().Play("HoverOff");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayButton.GetComponent<Animator>().Play ("HoverOn");
        //Debug.Log("The cursor entered the selectable UI element.");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PlayButton.GetComponent<Animator>().Play("HoverOff");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
