using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CubeCounterUI : MonoBehaviour
{
    [SerializeField] private CubeFactory _cubeFactory;

    private Text _cubeCountText;

    private void Start()
    {
        _cubeCountText = GetComponent<Text>();

        if (_cubeFactory == null)
        {
            Debug.LogError("CubeFactory не назначен в CubeCounterUI! Назначьте через Inspector.", this);
            return;
        }

        _cubeFactory.OnCubeCreated += OnCubeCountChanged;
        _cubeFactory.OnCubeDestroyed += OnCubeCountChanged;
        UpdateCounter();
    }

    private void OnCubeCountChanged(DividableCube cube)
    {
        UpdateCounter();
    }

    private void UpdateCounter()
    {
        if (_cubeCountText != null && _cubeFactory != null)
        {
            int count = _cubeFactory.GetActiveCubeCount();
            _cubeCountText.text = $"Кубы: {count}";
        }
    }

    private void OnDestroy()
    {
        if (_cubeFactory != null)
        {
            _cubeFactory.OnCubeCreated -= OnCubeCountChanged;
            _cubeFactory.OnCubeDestroyed -= OnCubeCountChanged;
        }
    }
}