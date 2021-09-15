using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBehaviour : MonoBehaviour
{
    private Vector3 _offset;
    private Camera _cam;

    private void Awake()
    {
        _cam = Camera.main;
    }

    private void OnMouseDown()
    {
        _offset = transform.position - GetMousePosition();
    }

    private Vector3 GetMousePosition()
    {
        var mousePos = _cam.ScreenToViewportPoint(Input.mousePosition) * 10;
        mousePos.z = 0;
        return mousePos;
    }
    private void OnMouseDrag()
    {
        var mousePos = GetMousePosition();
        transform.position = mousePos + _offset;
        Debug.Log(GetMousePosition());
    }
}
