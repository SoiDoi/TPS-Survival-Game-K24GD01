using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private InputActionReference _lookAction;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Transform _cameraHolder;
    [SerializeField] private float _minPitch;
    [SerializeField] private float _maxPitch;

    private float _pitch;

	private void Start()
	{
        _pitch = _cameraHolder.transform.localEulerAngles.x;
	}

	private void Update()
    {
        var input = _lookAction.action.ReadValue<Vector2>();
        UpdateYaw(input.x);
        UpdatePitch(input.y);
    }

    private void UpdateYaw(float inputX)
    {
        var deltaYaw = inputX * _rotateSpeed * Time.deltaTime;
        transform.Rotate(0, deltaYaw, 0);
    }

    private void UpdatePitch(float inputY)
    {
        var deltaPitch = -inputY * _rotateSpeed * Time.deltaTime;
        _pitch = Mathf.Clamp(_pitch + deltaPitch, _minPitch, _maxPitch);
        _cameraHolder.localRotation = Quaternion.Euler(_pitch, 0, 0);
    }
}
