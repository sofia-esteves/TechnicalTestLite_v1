using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackgroundBehaviour : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    /// <summary>
    /// MonoBehaviour to be associated to the background of the puzzle scenes
    /// Has actions to be performed on drop of an object
    /// </summary>

    public void OnDrop(PointerEventData eventData)
    {
        Handheld.Vibrate();
        var piecesPanel = GameObject.FindObjectOfType<PuzzlePiecesPanelManager>().transform;
        eventData.pointerDrag.transform.SetParent(piecesPanel);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
