using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Transform _rotator;

    private void Awake()
    {
        _rotator = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        _rotator.Rotate(0, _speed * Time.fixedDeltaTime, 0);
    }
}
