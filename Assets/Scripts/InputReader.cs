using UnityEngine;
using System;

public class InputReader : MonoBehaviour
{
    private Vector3 _previousMousePosition;

    internal event Action<Vector2> OnMouseClicked;
    internal event Action<Vector2> OnMousePositionChanged;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseClicked?.Invoke(Input.mousePosition);
        }

        if ((Vector3)Input.mousePosition != _previousMousePosition)
        {
            OnMousePositionChanged?.Invoke(Input.mousePosition);
            _previousMousePosition = Input.mousePosition;
        }
    }
}