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
                Debug.LogError("Volume에서 ColorAdjustments를 찾을 수 없습니다.");
            if(_volume.profile.TryGet<Bloom>(out _bloom) == false)
                Debug.LogError("Volume에서 Bloom을 찾을 수 없습니다.");

            _InitialEuler = _transform.eulerAngles;
        }

        public void OnUpdate()
        {
            Update();
        }

        void Update()
        {
            // 모델 시각 갱신
            _model.OnUpdate(Time.deltaTime);

            // 현재 시각 가져오기
            DateTime currentTime = _model.DateTime;

            // 현재 시간을 초 단위로 계산 (하루를 0 ~ 86400 초로)
            float secondsInDay = (currentTime.Hour * 3600) + (currentTime.Minute * 60) + currentTime.Second;
            float normalizedTime = secondsInDay / 86400f;

            // 목표 회전 각도 계산
            float xRotation = Mathf.Lerp(-90.0f, 270.0f, normalizedTime);

            // 현재 회전 및 목표 회전
            //Quaternion currentRotation = _transform.rotation;
            //Quaternion targetRotation = Quaternion.Euler(xRotation, _InitialEuler.y, _InitialEuler.z);

            // Slerp 사용하여 회전 보간
            _transform.rotation = Quaternion.Euler(xRotation, _InitialEuler.y, _InitialEuler.z);

            // 태양 각도를 기반으로 위쪽 방향 벡터와 내적 계산
            Vector3 sunDirection = _transform.forward; // 태양의 앞 방향
            float angle = Vector3.Dot(sunDirection, Vector3.down); // 태양과 위쪽 벡터의 내적을 이용해 각도 계산

            float intensity, postExposure, bloomIntensity;
            if (angle > 0) // 태양이 위에 있을 때 (낮)
            {
                float adjustedAngle = EaseOutExponential(0, 1, angle);
                intensity = Mathf.Lerp(_model.Config.EveningSunInfo.LightIntensity, _model.Config.NoonSunInfo.LightIntensity, adjustedAngle);
                postExposure = Mathf.Lerp(_model.Config.EveningSunInfo.PostExposure, _model.Config.NoonSunInfo.PostExposure, adjustedAngle);
                bloomIntensity = Mathf.Lerp(_model.Config.EveningSunInfo.BloomIntensity, _model.Config.NoonSunInfo.BloomIntensity, adjustedAngle);
                _lightColor = Color.Lerp(_model.Config.EveningSunInfo.LightColor, _model.Config.NoonSunInfo.LightColor, adjustedAngle);

                NormalizedIntensity = intensity / _model.Config.NoonSunInfo.LightIntensity;

                // 역광 효과
                float cameraLightAngle = Mathf.Clamp(Vector3.Dot(-sunDirection, Camera.main.transform.forward), 0, 1);
                intensity *= Mathf.Clamp(1 - cameraLightAngle, 0.5f, 1.0f);
            }
            else // 태양이 아래에 있을 때 (밤)
            {
                float adjustedAngle = EaseOutExponential(0, 1, -angle);
                intensity = Mathf.Lerp(_model.Config.EveningSunInfo.LightIntensity, _model.Config.MidnightSunInfo.LightIntensity, adjustedAngle);
                postExposure = Mathf.Lerp(_model.Config.EveningSunInfo.PostExposure, _model.Config.MidnightSunInfo.PostExposure, adjustedAngle);
                bloomIntensity = Mathf.Lerp(_model.Config.EveningSunInfo.BloomIntensity, _model.Config.MidnightSunInfo.BloomIntensity, adjustedAngle);
                _lightColor = Color.Lerp(_model.Config.EveningSunInfo.LightColor, _model.Config.MidnightSunInfo.LightColor, adjustedAngle);

                NormalizedIntensity = 0.0f;
            }

            // 조명, 색상 노출 값 적용
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


