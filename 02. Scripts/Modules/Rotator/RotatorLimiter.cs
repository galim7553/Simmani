using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 회전 제한 데이터를 관리하는 클래스.
    /// </summary>
    [Serializable]
    public class RotatorLimiter
    {
        [SerializeField]
        RotatorLimiterNode[] _limiters = new RotatorLimiterNode[3]
        {
            new RotatorLimiterNode(IRotator.AxisType.X, -180.0f, 180.0f),
            new RotatorLimiterNode(IRotator.AxisType.Y, -180.0f, 180.0f),
            new RotatorLimiterNode(IRotator.AxisType.Z, -180.0f, 180.0f)
        };

        /// <summary>
        /// 특정 축에 대해 제한된 각도를 반환합니다.
        /// </summary>
        /// <param name="axis">회전 축</param>
        /// <param name="angle">원본 각도</param>
        /// <returns>제한된 각도</returns>
        public float GetClampedEulerAngle(IRotator.AxisType axis, float angle)
        {
            return Mathf.Clamp(angle, _limiters[(int)axis].Min, _limiters[(int)axis].Max);
        }
    }

    /// <summary>
    /// 회전 제한 노드 데이터.
    /// </summary>
    [Serializable]
    public class RotatorLimiterNode
    {
        [ReadOnly][SerializeField] IRotator.AxisType _axis;

        [SerializeField] float _min = -180.0f;
        public float Min => _min;

        [SerializeField] float _max = 180.0f;
        public float Max => _max;

        /// <summary>
        /// RotatorLimiterNode 생성자.
        /// </summary>
        /// <param name="axis">회전 축</param>
        /// <param name="min">최소 각도</param>
        /// <param name="max">최대 각도</param>
        public RotatorLimiterNode(IRotator.AxisType axis, float min, float max)
        {
            _axis = axis;
            _min = min;
            _max = max;
        }
    }
}