using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Assets.Scripts.Levels;
using UnityEngine.SceneManagement;

public class GridBehaviour : MonoBehaviour
{
    /// <summary>
    /// Creates the puzzle grid with method GenerateGrid, puzzle size can be altered(puzzle piece sizing has to be adapted)
    /// as well as number of puzzle slots that are empty (difficulty can be changed)
    /// Method CheckIfWin called eveytime a puzzle piece is placed on the right slot, checks if puzzle is complete
    /// </summary>
    private int _width = 4;   
    private int _height =5;

    [SerializeField]
    private GameObject _tilesContent;
    [SerializeField]
    private GameObject _tilePrefab;
    public List<GameObject> TilesList;
    public List<GameObject> PuzzleTilesList;
    public List<(int, int)> PuzzleSlots = new List<(int, int)>();
    public GameObject Pieces;
    public GameObject WinMenu;
    public GameObject NextLevel;
    private void Start()
    {
        GenerateGrid();
        Pieces.SetActive(true);

        var level = GameObject.FindObjectOfType<LevelManager>();
        if (SceneManager.GetActiveScene().buildIndex < 3)
        {
            level.LevelsInfo.TryGetValue(SceneManager.GetActiveScene().buildIndex + 1, out bool isBlocked);
            if (!isBlocked)
            {
                NextLevel.SetActive(true);
            }
        }
        else
        {
            NextLevel.SetActive(true);
        }
    }
    void GenerateGrid()
    {
        var totalOfTiles = _width * _height;
        var numberOfPuzzleSlots = (int)totalOfTiles / 2;
       
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
                var tileBehaviour = tileInstance.GetComponent<TileBehaviour>();
                tileBehaviour.X = x;
                tileBehaviour.Y = y;

                if (isPuzzlePieceSlot)
                {
                    var slot = tileInstance.AddComponent<Image>();
                    var sceneManager = GameObject.FindObjectOfType<ScenesManager>();
                    var level = sceneManager.GetCurrentLevel();
                    if (level == LevelsEnum.FirstLevel)
                    {
                        slot.color = new Color((255f / 255f), (181f / 255f), (224f / 255f));
                    }
                    else if (level == LevelsEnum.SecondLevel)
                    {
                        slot.color = new Color((145f / 255f), (145f / 255f), (145f / 255f));
                    }
                    else if (level == LevelsEnum.ThirdLevel)
                    {
                        slot.color = new Color((100f / 255f), (75f / 255f), (100f / 255f));
                    }
                    PuzzleTilesList.Add(tileInstance);
                }
                var instanceRectTransform = tileInstance.GetComponent<RectTransform>();
                instanceRectTransform.anchoredPosition3D = new Vector3(x*150-_width*56.5f, y*150-_height*10);
                TilesList.Add(tileInstance);
            }
        }
    }
    public void CheckIfWin()
    {
        var numberOfCompletedTiles = 0;
        foreach(var tile in PuzzleTilesList)
        {
            var tileB = tile.GetComponent<TileBehaviour>();
            if (tileB.HasBeenOccupied)
            {
                numberOfCompletedTiles += 1;
            }
        }
        if (numberOfCompletedTiles == PuzzleTilesList.Count)
        {
            WinMenu.SetActive(true);
            GameObject.FindObjectOfType<ScenesManager>().UnlockNextLevel();
            if(!NextLevel.activeInHierarchy)
            {
                NextLevel.SetActive(true);
            }
            GameObject.FindObjectOfType<AudioManager>().PlaySound("Win");
        }
    }

}
