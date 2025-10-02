using UnityEngine;

public class CubeDivisionCoordinator : MonoBehaviour
{
    [SerializeField] private CubeRaycaster _cubeRaycaster;
    [SerializeField] private CubeFactory _cubeFactory;
    [SerializeField] private CubePhysicsForcer _physicsForcer;

    private void Start()
    {
        if (_cubeRaycaster == null || _cubeFactory == null || _physicsForcer == null)
        {
            Debug.LogError("¬се зависимости должны быть назначены в CubeDivisionCoordinator!", this);
            return;
        }

        _cubeRaycaster.OnCubeClicked += HandleCubeClick;
    }

    private void HandleCubeClick(DividableCube clickedCube)
    {
        if (clickedCube.CanSplit())
        {
            DividableCube[] newCubes = _cubeFactory.Split(clickedCube);

            if (newCubes != null && newCubes.Length > 0)
            {
                _physicsForcer.ApplyForcesToCubes(newCubes, clickedCube.transform.position);
            }
        }

        _cubeFactory.Destroy(clickedCube);
    }

    private void OnDestroy()
    {
        if (_cubeRaycaster != null)
            _cubeRaycaster.OnCubeClicked -= HandleCubeClick;
    }
}