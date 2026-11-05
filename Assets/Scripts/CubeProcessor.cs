using UnityEngine;

public class CubeProcessor : MonoBehaviour
{
    private readonly float _maxDivisionChance = 100f;
    private readonly float _minDivisionChance = 0f;
    private readonly int _maxCubesDivision = 6;
    private readonly int _minCubesDivision = 2;
    private readonly int _explosionForceScale = 1;
    private readonly int _explosionRadiusScale = 10;

    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private CubeSpawner _spawner = new CubeSpawner();
    [SerializeField] private Explosioner _explosioner = new Explosioner();

    private void OnEnable()
    {
        _raycaster.CubeTouched += ProcessCubeTouched;
    }

    private void OnDisable()
    {
        _raycaster.CubeTouched -= ProcessCubeTouched;
    }

    private void ProcessCubeTouched(Cube cube)
    {
        float chance = Random.Range(_maxDivisionChance, _minDivisionChance);

        if (cube.DivisionChance >= chance)
        {
            int cubesCount = Random.Range(_minCubesDivision, _maxCubesDivision);

            var cubes = _spawner.Spawn(cubesCount, cube);
            _explosioner.Explode(cube.transform.position, cubes);
        }
        else
        {
            var scaleMagnitude = cube.transform.localScale.magnitude;
            _explosioner.MakeExplosion(cube.transform.position, _explosionRadiusScale / scaleMagnitude, _explosionForceScale / scaleMagnitude);
        }
        
        _spawner.Remove(cube);
    }
}
