using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CubeCounterUI : MonoBehaviour
{
    private Text cubeCountText;
    private CubeFactory factory;

    private void Start()
    {
        cubeCountText = GetComponent<Text>();
        factory = FindObjectOfType<CubeFactory>();

        if (factory != null)
        {
            factory.OnCubeCreated += OnCubeCountChanged;
            factory.OnCubeDestroyed += OnCubeCountChanged;
        }

        UpdateCounter();
    }

    public void OnCubeCountChanged(DividableCube cube)
    {
        UpdateCounter();
    }

    private void UpdateCounter()
    {
        if (cubeCountText != null && factory != null)
        {
            int count = factory.GetActiveCubeCount();
            cubeCountText.text = $"Кубы: {count}";
        }
    }

    private void OnDestroy()
    {
        if (factory != null)
        {
            factory.OnCubeCreated -= OnCubeCountChanged;
            factory.OnCubeDestroyed -= OnCubeCountChanged;
        }
    }
}