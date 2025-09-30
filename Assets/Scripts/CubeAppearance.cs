using UnityEngine;

public class CubeAppearance : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;

    public void Initialize(Color color, Vector3 scale)
    {
        if (meshRenderer == null)
            meshRenderer = GetComponent<MeshRenderer>();

        if (meshRenderer.material != null)
            meshRenderer.material.color = color;

        transform.localScale = scale;
    }
}