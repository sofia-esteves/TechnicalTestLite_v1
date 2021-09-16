using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileBehaviour : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    int _xPosition;
    int _yPosition;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("dropped to" + gameObject.name);
        eventData.pointerDrag.transform.SetParent(transform.parent);
        eventData.pointerDrag.transform.position = transform.position;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
   
    }

    public void UpdateObjectPosition(int x, int y)
    {
        _xPosition = x;
        _yPosition = y;
    }
}
