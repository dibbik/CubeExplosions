using UnityEngine;
using System;

public class InputReader : MonoBehaviour
{
    public event Action<Vector2> OnMouseClicked;
    public event Action<Vector2> OnMousePositionChanged;

    private Vector3 previousMousePosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseClicked?.Invoke(Input.mousePosition);
        }

        if ((Vector3)Input.mousePosition != previousMousePosition)
        {
            OnMousePositionChanged?.Invoke(Input.mousePosition);
            previousMousePosition = Input.mousePosition;
        }
    }
}
