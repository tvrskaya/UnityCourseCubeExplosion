using UnityEngine;

public class Cube : MonoBehaviour
{
    private readonly int _maxCubesDivision = 6;
    private readonly int _minCubesDivision = 2;

    private float _divisionChance = 100f;

    public float DivisionChance { get; private set; } = 100f;

    public void Initialize(Vector3 position, Vector3 size, Color color, float divisionChance)
    {
        gameObject.transform.position = position;
        gameObject.transform.localScale = size;
        gameObject.GetComponent<Renderer>().material.color = color;

        DivisionChance = divisionChance;
    }
}
