using UnityEngine;
using System;

public class CubeRaycaster : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    internal event Action<DividableCube> OnCubeClicked;

    private void Start()
    {
        if (_mainCamera == null)
            _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryClickCube(Input.mousePosition);
        }
    }

    private void TryClickCube(Vector2 screenPosition)
    {
        if (_mainCamera == null)
            return;

        Ray ray = _mainCamera.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.TryGetComponent<DividableCube>(out DividableCube cube))
        {
            OnCubeClicked?.Invoke(cube);
        }
    }
}