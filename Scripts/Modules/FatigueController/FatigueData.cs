using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 피로도 데이터를 저장하는 클래스.
    /// </summary>
    [Serializable]
    public class FatigueData
    {
        [SerializeField] float _fatigue;
        /// <summary>
        /// 현재 피로도 값.
        /// </summary>
        public float Fatigue => _fatigue;

        /// <summary>
        /// 피로도 값을 설정합니다.
        /// </summary>
        public void SetFatigue(float fatigue)
        {
            _fatigue = fatigue;
        }
    }
}


