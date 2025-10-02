using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public class DividableCube : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;

    private float _splitChance;
    private Vector3 _scale;
    private Color _color;

    internal float SplitChance
    {
        get => _splitChance;
        private set => _splitChance = value;
    }

    internal Vector3 Scale
    {
        get => _scale;
        private set => _scale = value;
    }

    internal Color CubeColor
    {
        get => _color;
        private set => _color = value;
    }

    private void Awake()
    {
        if (_meshRenderer == null)
            _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Init(Color cubeColor, Vector3 cubeScale, float cubeSplitChance)
    {
        CubeColor = cubeColor;
        Scale = cubeScale;
        SplitChance = cubeSplitChance;

        if (_meshRenderer != null)
            _meshRenderer.material = new Material(_meshRenderer.material)
            {
                color = CubeColor
            };

        transform.localScale = Scale;
    }

    internal bool CanSplit()
    {
        return UnityEngine.Random.value <= SplitChance;
    }
}