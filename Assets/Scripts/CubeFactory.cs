using UnityEngine;
using System;
using System.Collections.Generic;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private DividableCube _cubePrefab;
    [SerializeField] private int _initialCubesCount = 5;
    [SerializeField] private CubePhysicsForcer _physicsForcer;
    private List<DividableCube> _activeCubes = new List<DividableCube>();

    internal event Action<DividableCube> OnCubeCreated;
    internal event Action<DividableCube> OnCubeDestroyed;

    private void Start()
    {
        if (_cubePrefab == null)
        {
            Debug.LogError("Префаб куба не назначен в CubeFactory!", this);
            return;
        }

        CreateInitialCubes();
    }

    private void CreateInitialCubes()
    {
        for (int i = 0; i < _initialCubesCount; i++)
        {
            Vector3 randomPos = new Vector3(
                UnityEngine.Random.Range(-8f, 8f),
                UnityEngine.Random.Range(2f, 8f),
                UnityEngine.Random.Range(-8f, 8f)
            );

            Color randomColor = new Color(
                UnityEngine.Random.Range(0.2f, 1f),
                UnityEngine.Random.Range(0.2f, 1f),
                UnityEngine.Random.Range(0.2f, 1f)
            );

            Create(randomPos, Vector3.one, UnityEngine.Random.ColorHSV(), 1f);
        }
    }

    internal DividableCube Create(Vector3 position, Vector3 scale, Color color, float splitChance)
    {
        DividableCube cube = Instantiate(_cubePrefab, position, Quaternion.identity);
        cube.Init(color, scale, splitChance);

        _activeCubes.Add(cube);
        OnCubeCreated?.Invoke(cube);

        return cube;
    }

    internal void Destroy(DividableCube cube)
    {
        if (cube != null)
        {
            _activeCubes.Remove(cube);
            OnCubeDestroyed?.Invoke(cube);
            Destroy(cube.gameObject);
        }
    }

    internal int GetActiveCubeCount() => _activeCubes.Count;

    internal DividableCube[] Split(DividableCube originalCube)
    {
        int newCubesCount = UnityEngine.Random.Range(2, 7);

        DividableCube[] newCubes = new DividableCube[newCubesCount];

        for (int i = 0; i < newCubesCount; i++)
        {
            Vector3 newScale = GetSplitScale(originalCube.Scale);
            Color newColor = GetSplitColor();

            float newSplitChance = GetSplitChance(originalCube.SplitChance);

            Vector3 randomOffset = new Vector3(
                UnityEngine.Random.Range(-0.5f, 0.5f),
                UnityEngine.Random.Range(-0.2f, 0.5f),
                UnityEngine.Random.Range(-0.5f, 0.5f)
            );

            Vector3 newPosition = originalCube.transform.position + randomOffset;
            newCubes[i] = Create(newPosition, newScale, newColor, newSplitChance);
        }

        return newCubes;
    }

    private Vector3 GetSplitScale(Vector3 originalScale)
    {
        return originalScale / 2f;
    }

    private Color GetSplitColor()
    {
        return new Color(
            UnityEngine.Random.Range(0.3f, 1f),
            UnityEngine.Random.Range(0.3f, 1f),
            UnityEngine.Random.Range(0.3f, 1f)
        );

    }

    private float GetSplitChance(float originalSplitChance)
    {
        return originalSplitChance / 2f;
    }
}