using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    private AudioManager audioManager;

    public void OnPointerDown(PointerEventData eventData)
    {
        //Handheld.Vibrate();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioManager.PlaySound("ButtonSound");
    }

    void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }
}
