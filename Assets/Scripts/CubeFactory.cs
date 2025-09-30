using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;

    [SerializeField] private int initialCubesCount = 5;
    [SerializeField] private float minExplosionForce = 8f;
    [SerializeField] private float maxExplosionForce = 15f;

    void Start()
    {
        CreateInitialCubes();
    }

    private void CreateInitialCubes()
    {
        if (cubePrefab == null) return;

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

    public GameObject CreateCube(Vector3 position, Vector3 scale, Color color, float splitChance)
    {
        if (cubePrefab == null) return null;

        GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);

        cube.GetComponent<CubeAppearance>()?.Initialize(color, scale);

        CubeSplitter splitter = cube.GetComponent<CubeSplitter>();
        if (splitter != null)
        {
            splitter.Initialize(splitChance, this);
        }

        CubeExploder exploder = cube.GetComponent<CubeExploder>();
        if (exploder != null)
        {
            exploder.SetExplosionSettings(minExplosionForce, maxExplosionForce);
        }

        return cube;
    }

    public void SetInitialCubesCount(int count) => initialCubesCount = count;
    public void SetExplosionForceRange(float min, float max)
    {
        minExplosionForce = min;
        maxExplosionForce = max;
    }
}