using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehaviour : MonoBehaviour
{
    [SerializeField]
    private int _width;
    [SerializeField]
    private int _height;
    [SerializeField]
    private GameObject _TilesContent;
    [SerializeField]
    private GameObject _tilePrefab;
    public List<GameObject> TilesList;


    private void Start()
    {
        GenerateGrid();
    }
    void GenerateGrid()
    {
        for(var x = 0; x<_width; x++)
        {
            for(var y = 0; y < _height; y++)
            {
                var tileInstance = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity, _TilesContent.transform);
                tileInstance.name = $"TileInstance ({x},{y})";
                var instanceRectTransform = tileInstance.GetComponent<RectTransform>();
                instanceRectTransform.anchoredPosition3D = new Vector3(x*150-225, y*150-500);
                TilesList.Add(tileInstance);
            }
        }
    }

}
