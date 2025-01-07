using GamePlay.Hubs.Equipments;
using UnityEngine;

namespace GamePlay.Hubs
{
    /// <summary>
    /// 횃불(Torch) 기어 클래스. 빛의 강도를 제어하는 기능 포함.
    /// </summary>
    public class Torch : Gear
    {
        Light _light; // 횃불의 빛
        ILightController _lightController; // 빛의 제어 인터페이스
        float _maxIntensity; // 횃불 라이트의 최대 밝기

        private void Awake()
        {
            _light = GetComponentInChildren<Light>(); // 자식 오브젝트에서 Light 컴포넌트 검색
            _maxIntensity = _light.intensity; // 초기 밝기를 최대 밝기로 설정
        }

        /// <summary>
        /// 빛 제어기를 설정합니다.
        /// </summary>
        /// <param name="lightController">빛 제어기 인터페이스</param>
        public void SetLightController(ILightController lightController)
        {
            _lightController = lightController;
            _light.intensity = (1 - _lightController.NormalizedIntensity) * _maxIntensity;
        }

        private void Update()
        {
            // 빛 제어기의 상태에 따라 밝기 조정
            if (_lightController != null)
                _light.intensity = (1 - _lightController.NormalizedIntensity) * _maxIntensity;
        }
    }
}

