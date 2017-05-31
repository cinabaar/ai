using UnityEngine;

class CameraRig : MonoBehaviour
{
    private Transform _playerTransform;
    private Vector3 _cameraOffset;

    private void Start()
    {
        _playerTransform = GameObject.Find("Player").transform;
        _cameraOffset = transform.position - _playerTransform.position;
    }

    private void LateUpdate()
    {
        if (_playerTransform)
        {
            transform.position = _playerTransform.position + _cameraOffset;
        }
    }
}
