using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ButtonBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        /// <summary>
        /// Puzzle Pieces button behaviour
        /// Actions to be performed on Drag
        /// </summary>

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
            var tiles = GameObject.FindObjectOfType<TileBehaviour>();
            if(transform.parent == parentTransform.parent)
            {
                transform.SetParent(parentTransform);
            }
            GetComponent<CanvasGroup>().blocksRaycasts = true;

        }
    }
}