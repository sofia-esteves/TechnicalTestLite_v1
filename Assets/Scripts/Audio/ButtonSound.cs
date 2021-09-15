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
        audioManager = AudioManager.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
