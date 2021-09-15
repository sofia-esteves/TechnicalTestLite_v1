using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    public GameObject AudioManager;
    private AudioManager audioManager;

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioManager.PlaySound("ButtonSound");
    }

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (audioManager == null)
    //    {
    //        audioManager = GameObject.FindObjectOfType<AudioManager>();
    //    }
    //}
}
