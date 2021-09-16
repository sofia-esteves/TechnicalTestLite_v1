using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GridBehaviour : MonoBehaviour
{
    private int _width = 4;   
    private int _height =5;

    [SerializeField]
    private GameObject _tilesContent;
    [SerializeField]
    private Sprite _sprite;
    [SerializeField]
    private GameObject _tilePrefab;
    public List<GameObject> TilesList;


    private void Start()
    {
        GenerateGrid();
    }
    void GenerateGrid()
    {
        var totalOfTiles = _width * _height;
        var numberOfPuzzleSlots = (int)totalOfTiles / 3;
        List<(int, int)> PuzzleSlots = new List<(int,int)>();
        while (PuzzleSlots.Count < numberOfPuzzleSlots)
        {
            var randomX = new System.Random();
            var x = randomX.Next(_width);
            var randomY = new System.Random();
            var y = randomY.Next(_height);
            if (PuzzleSlots.Count < 1)
            {
                (int, int) xy = (x, y);
                PuzzleSlots.Add(xy);
            }
            else
            {
                (int, int) SlotToBeAdded = (x, y);
                bool isToAdd = true;
                foreach (var slot in PuzzleSlots)
                {
                    if (slot.Item1 == x && slot.Item2 == y)
                    {
                        isToAdd = false;
                        
                    }
                }
                if (isToAdd)
                {
                    PuzzleSlots.Add(SlotToBeAdded);
                }
            }   
        }

        for (var x = 0; x<_width; x++)
        {
            for(var y = 0; y < _height; y++)
            {
                bool isPuzzlePieceSlot = false;
                foreach(var slot in PuzzleSlots)
                {
                    if (slot.Item1 == x && slot.Item2 == y)
                    {
                        isPuzzlePieceSlot = true;
                    }
                }

                var tileInstance = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity, _tilesContent.transform);
                tileInstance.name = $"TileInstance ({x},{y})";
                if (isPuzzlePieceSlot)
                {
                    //var slot = tileInstance.AddComponent<Image>();
                    //slot.sprite = _sprite;
                }
                var instanceRectTransform = tileInstance.GetComponent<RectTransform>();
                instanceRectTransform.anchoredPosition3D = new Vector3(x*150-_width*56.5f, y*150-_height*10);
                TilesList.Add(tileInstance);
            }
        }
    }

}
