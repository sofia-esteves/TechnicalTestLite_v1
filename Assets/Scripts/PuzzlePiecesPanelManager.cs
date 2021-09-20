using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PuzzlePiecesPanelManager : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        /// <summary>
        /// MonoBehaviour to be associated with the puzzle pieces panel
        /// Instaciates the Puzzle pieces prefab
        /// Actions to happen on drop
        /// </summary>
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private Sprite[] PuzzlePieces;
        public GameObject  Grid;


        private void Start()
        {
            var gridBehaviour = Grid.GetComponent<GridBehaviour>();
            var puzzleSlots = gridBehaviour.PuzzleSlots;
            foreach(var slot in puzzleSlots)
            {
                var pieceInstance = Instantiate(prefab, transform);
                pieceInstance.GetComponent<Image>().sprite = PuzzlePieces.ToList().Where(p => p.name == $"{slot.Item1}.{slot.Item2}").FirstOrDefault();
                var data = pieceInstance.GetComponent<PuzzlePiece>();
                data.X = slot.Item1;
                data.Y = slot.Item2;
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            var tile = eventData.pointerDrag.transform.parent.gameObject.GetComponent<TileBehaviour>();
            if (tile != null)
            {
                tile.HasBeenOccupied = false;
            }
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