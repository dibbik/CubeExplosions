using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    private CubeSplitter cubeSplitter;
    private CubeExploder cubeExploder;

    private bool isClicked = false;

    void Start()
    {
        cubeSplitter = GetComponent<CubeSplitter>();
        cubeExploder = GetComponent<CubeExploder>();
    }

    void OnMouseDown()
    {
        if (isClicked)
            return;

        isClicked = true;

        if (cubeSplitter != null && cubeSplitter.TrySplit(out GameObject[] newCubes))
        {
            if (cubeExploder != null)
            {
                cubeExploder.ExplodeNewCubes(newCubes, transform.position);
            }
        }

        Destroy(gameObject);
    }
}