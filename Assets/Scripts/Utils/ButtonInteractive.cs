using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonInteractive : MonoBehaviour,IPointerDownHandler,IPointerUpHandler 
{

    public bool pressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }
}
