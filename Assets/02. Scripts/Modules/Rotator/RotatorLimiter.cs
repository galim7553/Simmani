using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    [System.Serializable]
    public class RotatorLimiter
    {
        [SerializeField]
        RotatorLimiterNode[] _limiters = new RotatorLimiterNode[3]
        {
            new RotatorLimiterNode(IRotator.AxisType.X, -180.0f, 180.0f),
            new RotatorLimiterNode(IRotator.AxisType.Y, -180.0f, 180.0f),
            new RotatorLimiterNode(IRotator.AxisType.Z, -180.0f, 180.0f)
        };

        public float GetClampedEulerAngle(IRotator.AxisType axis, float angle)
        {
            return Mathf.Clamp(angle, _limiters[(int)axis].Min, _limiters[(int)axis].Max);
        }

    }

    [System.Serializable]
    public class RotatorLimiterNode
    {
        [ReadOnly] [SerializeField] IRotator.AxisType _axis;

        [SerializeField] float _min = -180.0f;
        public float Min => _min;

        [SerializeField] float _max = 180.0f;
        public float Max => _max;

        public RotatorLimiterNode(IRotator.AxisType axis, float min, float max)
        {
            _axis = axis;
            _min = min;
            _max = max;
        }
    }
}

