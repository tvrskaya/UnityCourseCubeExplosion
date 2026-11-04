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
}
