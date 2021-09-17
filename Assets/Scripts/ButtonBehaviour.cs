using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ButtonBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        Transform parentTransform = null;
        public void OnPointerDown(PointerEventData eventData)
        {
            
        }

        public void OnPointerEnter(PointerEventData eventData)
        {

        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            parentTransform = transform.parent;
            transform.SetParent(parentTransform.parent);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {

            if(transform.parent == parentTransform.parent)
            {
                transform.SetParent(parentTransform);
            }
            GetComponent<CanvasGroup>().blocksRaycasts = true;

        }
    }
}