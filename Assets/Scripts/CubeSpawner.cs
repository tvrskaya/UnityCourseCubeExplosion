using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CubeSpawner
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _sizeDivision = 2;
    [SerializeField] private int _chanceToDivide = 2;

    public List<Cube> Spawn(int amount, Cube spawnFrom)
    {
        List<Cube> cubes = new List<Cube>();

        for (int i = 0; i < amount; ++i)
        {
            Vector3 initPosition = Random.insideUnitSphere;
            initPosition.y = Mathf.Abs(initPosition.y);
            initPosition = spawnFrom.transform.position + initPosition;

            Vector3 initSize = spawnFrom.transform.localScale / _sizeDivision;

            Color initColor = Random.ColorHSV();

            var newCube = Object.Instantiate(_cubePrefab);
            newCube.Initialize(initPosition, initSize, initColor, spawnFrom.DivisionChance / _chanceToDivide);
        }

        return cubes;
    }

    public void Remove(Cube cube)
    {
        Object.Destroy(cube.gameObject);
    }
}
