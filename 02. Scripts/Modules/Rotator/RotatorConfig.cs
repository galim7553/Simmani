using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 회전 모듈의 설정 데이터를 구현한 클래스.
    /// </summary>
    [Serializable]
    public class RotatorConfig : IRotatorModel
    {
        [SerializeField] float _baseRotSpeed;
        [SerializeField] RotatorLimiter _rotatorLimiter = new RotatorLimiter();

        /// <summary>
        /// 회전 속도.
        /// </summary>
        float IRotatorModel.RotSpeed => _baseRotSpeed;

        /// <summary>
        /// 회전 제한 데이터.
        /// </summary>
        RotatorLimiter IRotatorModel.RotatorLimiter => _rotatorLimiter;
    }
}