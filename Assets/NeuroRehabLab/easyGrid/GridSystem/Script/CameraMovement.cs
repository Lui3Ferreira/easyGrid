using UnityEngine;

namespace CameraManip
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        private float _dragSpeed = 1, _zoomSpeed;
        private Vector3 _dragOrigin;
        [SerializeField]
        private Camera _camera;

        public void Update()
        {
            MouseCameraMovement();
            MouseCameraZoom();
        }

        //Function resposponsible for vertical and horizontal movement of the camera
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

        //Function resposponsible for zoom in/out of the camera
        private void MouseCameraZoom()
        {
            _camera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed;
        }
    }
}

