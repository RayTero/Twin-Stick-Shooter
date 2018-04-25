using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _followRatio; //at what percentage of the screen the player should be when we are at our max move range

    [SerializeField] private float _cameraHeight;

    private Vector3 _newPosition = Vector3.zero;
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _newPosition.y = _cameraHeight;
    }

    private void Update()
    {
        //_newPosition = new Vector3(_player.position.x, _cameraHeight, _player.position.z);
        Vector3 delta = GetMoveDelta(Input.mousePosition).normalized;

        if (CanMoveCamera(delta))
        {
            _newPosition.x += delta.x * 1 * Time.deltaTime;
            _newPosition.z += delta.y * 1 * Time.deltaTime;
        }

        transform.position = _newPosition;
    }

    private bool CanMoveCamera(Vector3 delta)
    {
        Vector3 _playerPositionInScreenSpace = _camera.WorldToViewportPoint(_player.position);

        if (_playerPositionInScreenSpace.x > _followRatio && _playerPositionInScreenSpace.x < 1 - _followRatio)
        {
            if (_playerPositionInScreenSpace.y > _followRatio && _playerPositionInScreenSpace.y < 1 - _followRatio)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// NiggasBeBlack
    /// </summary>
    /// <returns></returns>
    private Vector3 GetMoveDelta(Vector3 vector)
    {
        Vector3 mousePosition = _camera.ScreenToViewportPoint(vector);

        if (mousePosition.x > 1f)
            mousePosition.x -= 1f;
        else if (mousePosition.x < 1f)
            mousePosition.x += 1f;

        if (mousePosition.y > 1f)
            mousePosition.y -= 1f;
        else if (mousePosition.y < 1f)
            mousePosition.y += 1f;

        return mousePosition;
    }

    private void MoveCamera()
    {
        transform.position = _newPosition;
    }
}
