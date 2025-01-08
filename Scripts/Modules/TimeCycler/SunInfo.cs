using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 태양의 조명 정보 및 환경 설정을 담는 데이터 클래스.
    /// </summary>
    [Serializable]
    public class SunInfo
    {
        [SerializeField] float _lightIntensity;
        [SerializeField] float _postExposure;
        [SerializeField] float _bloomIntensity;
        [SerializeField] Color _lightColor;

        /// <summary>태양광의 강도.</summary>
        public float LightIntensity => _lightIntensity;

        /// <summary>포스트 프로세싱 노출 값.</summary>
        public float PostExposure => _postExposure;

        /// <summary>Bloom 효과 강도.</summary>
        public float BloomIntensity => _bloomIntensity;

        /// <summary>태양광의 색상.</summary>
        public Color LightColor => _lightColor;
    }
}


