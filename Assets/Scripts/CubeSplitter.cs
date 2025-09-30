using UnityEngine;

public class CubeSplitter : MonoBehaviour
{
    private float splitChance;
    private CubeFactory cubeFactory;

    public void Initialize(float chance, CubeFactory factory)
    {
        splitChance = chance;
        cubeFactory = factory;
    }

    public bool TrySplit(out GameObject[] newCubes)
    {
        newCubes = null;

        if (Random.value > splitChance)
        {
            return false;
        }

        int count = Random.Range(2, 7);

        newCubes = new GameObject[count];


        for (int i = 0; i < count; i++)
        {
            Vector3 randomOffset = new Vector3(
                Random.Range(-0.5f, 0.5f),
                Random.Range(-0.2f, 0.5f),
                Random.Range(-0.5f, 0.5f)
            );

            newCubes[i] = cubeFactory.CreateCube(
                transform.position + randomOffset,
                transform.localScale / 2f,
                Random.ColorHSV(),
                splitChance / 2f
            );
        }

        return true;
    }
}