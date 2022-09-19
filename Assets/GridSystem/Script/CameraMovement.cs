using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float _dragSpeed = 1;
    private Vector3 _dragOrigin;
    [SerializeField]
    private Camera _camera;

    void Update()
    {
        MouseCameraMovement();
        MouseCameraZoom();
    }

    private void MouseCameraMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _dragOrigin = Input.mousePosition;
            return;
        }

        if (Input.GetMouseButton(0) == false) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - _dragOrigin);
        Vector3 move = new Vector3(pos.x * _dragSpeed, pos.y * _dragSpeed, 0);

        transform.Translate(move.x, move.y, move.z, Space.World);
    }

    private void MouseCameraZoom()
    {
        _camera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel")*10;
    }
}
