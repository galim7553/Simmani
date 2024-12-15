using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMover : MonoBehaviour
{
    enum QualityLevelType
    {
        Low,
        Med,
        High,
        Ultra
    }

    [SerializeField] Terrain _targetTerrain;
    [SerializeField] float _rotSpeed = 100.0f;
    [SerializeField] float _xRotLimit = 15.0f;
    [SerializeField] float _moveSpeed = 10.0f;

    float _mouseX = 0;
    float _mouseY = 0;

    Vector3 _rotEuler = Vector3.zero;

    float _h = 0;
    float _v = 0;

    Vector3 _position = Vector3.zero;
    float _offsetY = 0;

    QualityLevelType _qualityLevelType;
    float _deltaTime = 0;

    private void Awake()
    {
        _offsetY = transform.position.y - _targetTerrain.SampleHeight(transform.position);
        _rotEuler = transform.eulerAngles;
        _qualityLevelType = (QualityLevelType)QualitySettings.GetQualityLevel();
    }

    void Update()
    {
        // ----- Move & Rotate ----- //
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");

        _rotEuler.y += _mouseX * _rotSpeed * Time.deltaTime;
        _rotEuler.x -= _mouseY * _rotSpeed * Time.deltaTime;

        _rotEuler.x = Mathf.Clamp(_rotEuler.x, -_xRotLimit, _xRotLimit);

        transform.eulerAngles = _rotEuler;

        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * _v * _moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * _h * _moveSpeed * Time.deltaTime);

        _position = transform.position;
        _position.y = _targetTerrain.SampleHeight(_position) + _offsetY;
        transform.position = _position;
        // ----- Move & Rotate ----- //

        // ----- Quality ----- //
        if(Input.GetKeyDown(KeyCode.Alpha1) == true)
        {
            _qualityLevelType = QualityLevelType.Low;
            QualitySettings.SetQualityLevel((int)_qualityLevelType, true);
        }
            
        if(Input.GetKeyDown(KeyCode.Alpha2) == true)
        {
            _qualityLevelType = QualityLevelType.Med;
            QualitySettings.SetQualityLevel((int)_qualityLevelType, true);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) == true)
        {
            _qualityLevelType = QualityLevelType.High;
            QualitySettings.SetQualityLevel((int)_qualityLevelType, true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) == true)
        {
            _qualityLevelType = QualityLevelType.Ultra;
            QualitySettings.SetQualityLevel((int)_qualityLevelType, true);
        }

        _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.1f;
        // ----- Quality ----- //
    }

    private void OnGUI()
    {
        // 화면에 표시될 텍스트 스타일 설정
        GUIStyle style = new GUIStyle();
        int width = Screen.width, height = Screen.height;
        Rect rect = new Rect(width - 120, 10, 100, 20); // 우측 상단에 위치
        style.alignment = TextAnchor.UpperRight;
        style.fontSize = 24;
        style.normal.textColor = Color.white;

        // FPS 계산 및 텍스트로 변환
        float msec = _deltaTime * 1000.0f;
        float fps = 1.0f / _deltaTime;
        string text = string.Format("QualityLevel:{0}, {1:0.0} ms ({2:0.} FPS)", _qualityLevelType, msec, fps);

        // 화면에 텍스트 출력
        GUI.Label(rect, text, style);
    }
}
