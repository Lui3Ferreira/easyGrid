using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTranslate : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    //Will assign default values to the camera
    public void MoveCameraToCenter()
    {
        _camera.transform.position = new Vector3(0, 0, -10); ;
        _camera.fieldOfView = 60f;
    }
}
