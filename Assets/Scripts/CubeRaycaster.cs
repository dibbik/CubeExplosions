using UnityEngine;
using System;

public class CubeRaycaster : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    public event Action<DividableCube> OnCubeClicked;

    private void Start()
    {
        if (mainCamera == null) mainCamera = Camera.main;
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
        if (mainCamera == null) return;

        Ray ray = mainCamera.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.TryGetComponent<DividableCube>(out DividableCube cube))
        {
            OnCubeClicked?.Invoke(cube);
        }
    }
}