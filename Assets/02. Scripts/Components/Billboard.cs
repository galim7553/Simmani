using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Transform _cameraTransform;
    private void Start()
    {
        FindMainCameraTransform();
    }

    private void Update()
    {
        if (_cameraTransform == null)
            FindMainCameraTransform();
        transform.LookAt(transform.position + _cameraTransform.rotation * Vector3.forward,
                         _cameraTransform.rotation * Vector3.up);
    }

    void FindMainCameraTransform()
    {
        _cameraTransform = Camera.main.transform;
    }
}
