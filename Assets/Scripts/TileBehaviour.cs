using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileBehaviour : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool HasBeenOccupied;

    public void OnDrop(PointerEventData eventData)
    {
        if (!HasBeenOccupied)
        {
            HasBeenOccupied = true;
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.transform.position = transform.position;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
   
    }
}
