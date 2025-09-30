using UnityEngine;
using UnityEngine.UI;

public class CubeCounterManager : MonoBehaviour
{
    [SerializeField] private Text cubeCountText;

    void Update()
    {
        int cubeCount = FindObjectsOfType<CubeClickHandler>().Length;

        if (cubeCountText != null)
        {
            cubeCountText.text = $"Кубы: {cubeCount}";
        }
    }
}