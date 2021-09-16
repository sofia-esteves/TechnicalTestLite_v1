using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class PuzzlePiecesPanelManager : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private GameObject prefab;

        public void OnDrop(PointerEventData eventData)
        {

            eventData.pointerDrag.transform.SetParent(transform);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
        }

        public void OnPointerExit(PointerEventData eventData)
        {
        }
    }
}