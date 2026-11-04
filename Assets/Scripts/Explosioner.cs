using UnityEngine;

public class Explosioner : MonoBehaviour
{
    private readonly int _maxCubesDivision = 6;
    private readonly int _minCubesDivision = 2;
    private readonly float _maxDivisionChance = 100f;
    private readonly float _minDivisionChance = 0f;
    private readonly int _divisionChanceDivision = 2;
    private readonly int _sizeDivision = 2;

    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private float _explosionForce = 1000f;

    private float _divisionChance = 100f;

    public void Initialize(Vector3 position, Vector3 size, Color color, float divisionChance, GameObject cubePrefab)
    {
        gameObject.transform.position = position;
        gameObject.transform.localScale = size;
        gameObject.GetComponent<Renderer>().material.color = color;

        _cubePrefab = cubePrefab;
        _divisionChance = divisionChance;
    }

    public void Explode()
    {
        float chance = Random.Range(_maxDivisionChance, _minDivisionChance);

        if (_divisionChance >= chance)
        {
            int cubesCount = Random.Range(_minCubesDivision, _maxCubesDivision);

            for (int i = 0; i < cubesCount; ++i)
            {
                Vector3 initPosition = Random.insideUnitSphere;
                initPosition.y = Mathf.Abs(initPosition.y);
                initPosition = transform.position + initPosition;

                Vector3 initSize = transform.localScale / _sizeDivision;

                Color initColor = Random.ColorHSV();

                Vector3 explosionForce = (initPosition - transform.position).normalized * _explosionForce;

                var newCube = Instantiate(_cubePrefab);
                newCube.GetComponent<Explosioner>().Initialize(initPosition, initSize, initColor, _divisionChance / _divisionChanceDivision, _cubePrefab);
                newCube.GetComponent<Rigidbody>().AddForce(explosionForce, ForceMode.Impulse);
            }   
        }

        Destroy(gameObject);
    }
}
