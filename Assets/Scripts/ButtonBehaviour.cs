using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class ButtonBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        Transform puzzlePiecesContent = null;
        public void OnPointerDown(PointerEventData eventData)
        {
            
        }

        public void OnPointerEnter(PointerEventData eventData)
        {

        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            puzzlePiecesContent = transform.parent;
            transform.SetParent(transform.parent.parent);

            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //transform.SetParent(puzzlePiecesContent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;

        }
    }
}