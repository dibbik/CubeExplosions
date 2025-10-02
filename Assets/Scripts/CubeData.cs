using UnityEngine;

[System.Serializable]
public class CubeData
{
    public Vector3 Position;
    public Vector3 Scale;
    public Color Color;
    public float SplitChance;

    public CubeData(Vector3 position, Vector3 scale, Color color, float splitChance)
    {
        Position = position;
        Scale = scale;
        Color = color;
        SplitChance = splitChance;
    }
}