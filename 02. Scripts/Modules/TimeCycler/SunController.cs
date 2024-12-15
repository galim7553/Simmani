using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace GamePlay.Modules
{
    public class SunController : ModuleBase, IUpdatable, ILightController
    {
        ITimeCycleModel _model;

        Light _light;
        Volume _volume;
        Transform _transform;
        ColorAdjustments _colorAdjustments;
        Bloom _bloom;

        Vector3 _InitialEuler;
        Color _lightColor;

        public float NormalizedIntensity { get; private set; }

        public SunController(ITimeCycleModel model, Light light, Volume volume)
        {
            _model = model;
            _light = light;
            _volume = volume;
            _transform = _light.transform;
            if (_volume.profile.TryGet<ColorAdjustments>(out _colorAdjustments) == false)
                Debug.LogError("Volume���� ColorAdjustments�� ã�� �� �����ϴ�.");
            if(_volume.profile.TryGet<Bloom>(out _bloom) == false)
                Debug.LogError("Volume���� Bloom�� ã�� �� �����ϴ�.");

            _InitialEuler = _transform.eulerAngles;
        }

        public void OnUpdate()
        {
            Update();
        }

        void Update()
        {
            // �� �ð� ����
            _model.OnUpdate(Time.deltaTime);

            // ���� �ð� ��������
            DateTime currentTime = _model.DateTime;

            // ���� �ð��� �� ������ ��� (�Ϸ縦 0 ~ 86400 �ʷ�)
            float secondsInDay = (currentTime.Hour * 3600) + (currentTime.Minute * 60) + currentTime.Second;
            float normalizedTime = secondsInDay / 86400f;

            // ��ǥ ȸ�� ���� ���
            float xRotation = Mathf.Lerp(-90.0f, 270.0f, normalizedTime);

            // ���� ȸ�� �� ��ǥ ȸ��
            //Quaternion currentRotation = _transform.rotation;
            //Quaternion targetRotation = Quaternion.Euler(xRotation, _InitialEuler.y, _InitialEuler.z);

            // Slerp ����Ͽ� ȸ�� ����
            _transform.rotation = Quaternion.Euler(xRotation, _InitialEuler.y, _InitialEuler.z);

            // �¾� ������ ������� ���� ���� ���Ϳ� ���� ���
            Vector3 sunDirection = _transform.forward; // �¾��� �� ����
            float angle = Vector3.Dot(sunDirection, Vector3.down); // �¾�� ���� ������ ������ �̿��� ���� ���

            float intensity, postExposure, bloomIntensity;
            if (angle > 0) // �¾��� ���� ���� �� (��)
            {
                float adjustedAngle = EaseOutExponential(0, 1, angle);
                intensity = Mathf.Lerp(_model.Config.EveningSunInfo.LightIntensity, _model.Config.NoonSunInfo.LightIntensity, adjustedAngle);
                postExposure = Mathf.Lerp(_model.Config.EveningSunInfo.PostExposure, _model.Config.NoonSunInfo.PostExposure, adjustedAngle);
                bloomIntensity = Mathf.Lerp(_model.Config.EveningSunInfo.BloomIntensity, _model.Config.NoonSunInfo.BloomIntensity, adjustedAngle);
                _lightColor = Color.Lerp(_model.Config.EveningSunInfo.LightColor, _model.Config.NoonSunInfo.LightColor, adjustedAngle);

                NormalizedIntensity = intensity / _model.Config.NoonSunInfo.LightIntensity;

                // ���� ȿ��
                float cameraLightAngle = Mathf.Clamp(Vector3.Dot(-sunDirection, Camera.main.transform.forward), 0, 1);
                intensity *= Mathf.Clamp(1 - cameraLightAngle, 0.5f, 1.0f);
            }
            else // �¾��� �Ʒ��� ���� �� (��)
            {
                float adjustedAngle = EaseOutExponential(0, 1, -angle);
                intensity = Mathf.Lerp(_model.Config.EveningSunInfo.LightIntensity, _model.Config.MidnightSunInfo.LightIntensity, adjustedAngle);
                postExposure = Mathf.Lerp(_model.Config.EveningSunInfo.PostExposure, _model.Config.MidnightSunInfo.PostExposure, adjustedAngle);
                bloomIntensity = Mathf.Lerp(_model.Config.EveningSunInfo.BloomIntensity, _model.Config.MidnightSunInfo.BloomIntensity, adjustedAngle);
                _lightColor = Color.Lerp(_model.Config.EveningSunInfo.LightColor, _model.Config.MidnightSunInfo.LightColor, adjustedAngle);

                NormalizedIntensity = 0.0f;
            }

            // ����, ���� ���� �� ����
            _light.intensity = intensity;
            _light.color = _lightColor;
            _colorAdjustments.postExposure.value = postExposure;
            _bloom.intensity.value = bloomIntensity;
        }
        float EaseOutExponential(float start, float end, float t)
        {
            t = t * t;
            t = 1 - Mathf.Pow(2, -10 * t);
            return Mathf.Lerp(start, end, t);
        }

        
    }
}


