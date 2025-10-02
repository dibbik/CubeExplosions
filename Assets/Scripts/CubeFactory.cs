using UnityEngine;
using System.Collections.Generic;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private DividableCube cubePrefab;
    [SerializeField] private int initialCubesCount = 5;

    public event System.Action<DividableCube> OnCubeCreated;
    public event System.Action<DividableCube> OnCubeDestroyed;

    private List<DividableCube> activeCubes = new List<DividableCube>();

    private void Start()
    {
        CreateInitialCubes();
    }

    private void CreateInitialCubes()
    {
        for (int i = 0; i < initialCubesCount; i++)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(-8f, 8f),
                Random.Range(2f, 8f),
                Random.Range(-8f, 8f)
            );

            CreateCube(randomPos, Vector3.one, Random.ColorHSV(), 1f);
        }
    }

    public DividableCube CreateCube(Vector3 position, Vector3 scale, Color color, float splitChance)
    {
        DividableCube cube = Instantiate(cubePrefab, position, Quaternion.identity);
        cube.Init(color, scale, splitChance);

        activeCubes.Add(cube);
        OnCubeCreated?.Invoke(cube);

        return cube;
    }

    public DividableCube[] SplitCube(DividableCube originalCube)
    {
        int newCubesCount = Random.Range(2, 7);

        DividableCube[] newCubes = new DividableCube[newCubesCount];

        for (int i = 0; i < newCubesCount; i++)
        {
            originalCube.GetSplitParameters(out Vector3 newScale, out Color newColor, out float newSplitChance);

            Vector3 randomOffset = new Vector3(
                Random.Range(-0.5f, 0.5f),
                Random.Range(-0.2f, 0.5f),
                Random.Range(-0.5f, 0.5f)
            );

            Vector3 newPosition = originalCube.transform.position + randomOffset;
            newCubes[i] = CreateCube(newPosition, newScale, newColor, newSplitChance);
        }

        return newCubes;
    }

    public void DestroyCube(DividableCube cube)
    {
        if (cube != null)
        {
            activeCubes.Remove(cube);
            OnCubeDestroyed?.Invoke(cube);
            Destroy(cube.gameObject);
        }
    }

    public int GetActiveCubeCount() => activeCubes.Count;
}