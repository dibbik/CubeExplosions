using UnityEngine;

public class CubePhysicsForcer : MonoBehaviour
{
    [SerializeField] private float _minExplosionForce = 8f;
    [SerializeField] private float _maxExplosionForce = 15f;

    internal void ApplyForcesToCubes(DividableCube[] cubes, Vector3 explosionCenter)
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

                    float force = Random.Range(_minExplosionForce, _maxExplosionForce);
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

    internal void SetForceRange(float min, float max)
    {
        _minExplosionForce = min;
        _maxExplosionForce = max;
    }
}