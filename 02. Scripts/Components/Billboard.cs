using UnityEngine;

/// <summary>
/// ī�޶� ������ ���󰡴� ������ ������Ʈ.
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
        // ���� ī�޶� �Ҵ���� ���� ��� �ٽ� ã��
        if (_cameraTransform == null)
            FindMainCameraTransform();

        // �����尡 �׻� ī�޶� ���ϵ��� ����
        transform.LookAt(transform.position + _cameraTransform.rotation * Vector3.forward,
                         _cameraTransform.rotation * Vector3.up);
    }

    /// <summary>
    /// ���� ī�޶��� Transform�� ã��.
    /// </summary>
    void FindMainCameraTransform()
    {
        _cameraTransform = Camera.main.transform;
    }
}
