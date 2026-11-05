using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Explosioner
{
    [SerializeField] private float _explosionForce = 100f;

    public void Explode(Vector3 explosionPoint, List<Cube> cubes)
    {
        foreach (var cube in cubes)
        {
            Vector3 explosionForce = (explosionPoint - cube.transform.position).normalized * _explosionForce;

            cube.GetComponent<Rigidbody>().AddForce(explosionForce, ForceMode.Impulse);
        }
    }

    public void MakeExplosion(Vector3 explosionPoint, float explosionRadius, float explosionForceScale)
    {
        Collider[] hits = Physics.OverlapSphere(explosionPoint, explosionRadius);
        
        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                hit.attachedRigidbody.AddExplosionForce(_explosionForce * explosionForceScale, explosionPoint, explosionRadius);
            }
        }
    }
}
