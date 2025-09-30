using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    private float minExplosionForce = 5f;
    private float maxExplosionForce = 15f;

    public void SetExplosionSettings(float minForce, float maxForce)
    {
        minExplosionForce = minForce;
        maxExplosionForce = maxForce;
    }

    public void ExplodeNewCubes(GameObject[] cubes, Vector3 explosionCenter)
    {
        foreach (GameObject cube in cubes)
        {
            Rigidbody rigidbody = cube.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                Vector3 randomDirection = Random.onUnitSphere;

                float force = Random.Range(minExplosionForce, maxExplosionForce);

                rigidbody.AddForce(randomDirection * force, ForceMode.Impulse);

                Vector3 randomTorque = new Vector3(
                    Random.Range(-20f, 20f),
                    Random.Range(-20f, 20f),
                    Random.Range(-20f, 20f)
                );
                rigidbody.AddTorque(randomTorque, ForceMode.Impulse);
            }
        }
    }
}