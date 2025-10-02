using UnityEngine;

public class CubePhysicsForcer : MonoBehaviour
{
    [SerializeField] private float minExplosionForce = 8f;
    [SerializeField] private float maxExplosionForce = 15f;

    public void ApplyForcesToCubes(DividableCube[] cubes, Vector3 explosionCenter)
    {
        foreach (DividableCube cube in cubes)
        {
            if (cube != null)
            {
                Rigidbody rigidbody = cube.GetComponent<Rigidbody>();
                if (rigidbody != null)
                {
                    Vector3 direction = (cube.transform.position - explosionCenter).normalized;
                    if (direction.magnitude < 0.1f) direction = Random.onUnitSphere;

                    float force = Random.Range(minExplosionForce, maxExplosionForce);
                    rigidbody.AddForce(direction * force, ForceMode.Impulse);

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
}