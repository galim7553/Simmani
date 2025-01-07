using UnityEngine;

/// <summary>
/// 카메라 방향을 따라가는 빌보드 컴포넌트.
/// </summary>
public class Billboard : MonoBehaviour
{
    Transform _cameraTransform;
    private void Start()
    {
        FindMainCameraTransform();
    }

    private void Update()
    {
        // 메인 카메라가 할당되지 않은 경우 다시 찾음
        if (_cameraTransform == null)
            FindMainCameraTransform();

        // 빌보드가 항상 카메라를 향하도록 설정
        transform.LookAt(transform.position + _cameraTransform.rotation * Vector3.forward,
                         _cameraTransform.rotation * Vector3.up);
    }

    /// <summary>
    /// 메인 카메라의 Transform을 찾음.
    /// </summary>
    void FindMainCameraTransform()
    {
        _cameraTransform = Camera.main.transform;
    }
}
