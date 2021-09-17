using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TileBehaviour : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool HasBeenOccupied;
    public int X;
    public int Y;

    public void OnDrop(PointerEventData eventData)
    {
        var positionData = eventData.pointerDrag.GetComponent<PuzzlePiece>();
        if(positionData.X==X && positionData.Y == Y)
        {
            HasBeenOccupied = true;
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.transform.position = transform.position;
            var gridB = GameObject.FindObjectOfType<GridBehaviour>();
            var audio = GameObject.FindObjectOfType<AudioManager>();
            audio.PlaySound("ButtonSound");
            gridB.CheckIfWin();
        }
        else
        {
            Handheld.Vibrate();
            var piecesPanel = GameObject.FindObjectOfType<PuzzlePiecesPanelManager>().transform;
            eventData.pointerDrag.transform.SetParent(piecesPanel);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
   
    }
}
