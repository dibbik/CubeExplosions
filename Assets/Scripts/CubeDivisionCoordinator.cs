using UnityEngine;

public class CubeDivisionCoordinator : MonoBehaviour
{
    [SerializeField] private CubeRaycaster cubeRaycaster;
    [SerializeField] private CubeFactory cubeFactory;
    [SerializeField] private CubePhysicsForcer physicsForcer;

    private void Start()
    {
        cubeRaycaster.OnCubeClicked += HandleCubeClick;
    }

    private void HandleCubeClick(DividableCube clickedCube)
    {
        if (Random.value <= clickedCube.SplitChance)
        {
            DividableCube[] newCubes = cubeFactory.SplitCube(clickedCube);

            if (newCubes != null && newCubes.Length > 0)
            {
                physicsForcer.ApplyForcesToCubes(newCubes, clickedCube.transform.position);
            }
        }

        cubeFactory.DestroyCube(clickedCube);
    }

    private void OnDestroy()
    {
        if (cubeRaycaster != null)
            cubeRaycaster.OnCubeClicked -= HandleCubeClick;
    }
}