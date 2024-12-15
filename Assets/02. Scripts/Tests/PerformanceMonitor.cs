using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceMonitor : MonoBehaviour
{
    enum QualityLevelType
    {
        Low,
        Med,
        High,
        Ultra
    }

    QualityLevelType _qualityLevelType;
    float _deltaTime;

    private void Awake()
    {
        _qualityLevelType = (QualityLevelType)QualitySettings.GetQualityLevel();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1) == true)
        {
            _qualityLevelType = QualityLevelType.Low;
            QualitySettings.SetQualityLevel((int)_qualityLevelType, true);
        }

        if (Input.GetKeyDown(KeyCode.F2) == true)
        {
            _qualityLevelType = QualityLevelType.Med;
            QualitySettings.SetQualityLevel((int)_qualityLevelType, true);
        }
        if (Input.GetKeyDown(KeyCode.F3) == true)
        {
            _qualityLevelType = QualityLevelType.High;
            QualitySettings.SetQualityLevel((int)_qualityLevelType, true);
        }
        if (Input.GetKeyDown(KeyCode.F4) == true)
        {
            _qualityLevelType = QualityLevelType.Ultra;
            QualitySettings.SetQualityLevel((int)_qualityLevelType, true);
        }

        _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.1f;
    }
    private void OnGUI()
    {
        // ȭ�鿡 ǥ�õ� �ؽ�Ʈ ��Ÿ�� ����
        GUIStyle style = new GUIStyle();
        int width = Screen.width, height = Screen.height;
        Rect rect = new Rect(width - 120, 10, 100, 20); // ���� ��ܿ� ��ġ
        style.alignment = TextAnchor.UpperRight;
        style.fontSize = 24;
        style.normal.textColor = Color.white;

        // FPS ��� �� �ؽ�Ʈ�� ��ȯ
        float msec = _deltaTime * 1000.0f;
        float fps = 1.0f / _deltaTime;
        string text = string.Format("QualityLevel:{0}, {1:0.0} ms ({2:0.} FPS)", _qualityLevelType, msec, fps);

        // ȭ�鿡 �ؽ�Ʈ ���
        GUI.Label(rect, text, style);
    }
}
