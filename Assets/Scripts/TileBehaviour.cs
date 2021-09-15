using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    int _xPosition;
    int _yPosition;

    public void UpdateObjectPosition(int x, int y)
    {
        _xPosition = x;
        _yPosition = y;
    }
}
