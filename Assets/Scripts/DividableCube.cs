using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public class DividableCube : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;

    private float splitChance;
    private Vector3 scale;
    private Color color;

    public float SplitChance => splitChance;
    public Vector3 Scale => scale;
    public Color CubeColor => color;

    public void Init(Color cubeColor, Vector3 cubeScale, float cubeSplitChance)
    {
        color = cubeColor;
        scale = cubeScale;
        splitChance = cubeSplitChance;

        if (meshRenderer != null)
            meshRenderer.material.color = color;

        transform.localScale = scale;
    }

    public void GetSplitParameters(out Vector3 newScale, out Color newColor, out float newSplitChance)
    {
        newScale = scale / 2f;
        newColor = UnityEngine.Random.ColorHSV();
        newSplitChance = splitChance / 2f;
    }
}