using UnityEngine;
using UnityEngine.InputSystem;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private int _maxRayDistance = 100;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _maxRayDistance))
            {
                if (hit.collider.TryGetComponent<Explosioner>(out var explosioner))
                {
                    explosioner.Explode();
                }
            }
        }
    }
}
