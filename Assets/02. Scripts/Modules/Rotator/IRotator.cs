using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 대상 회전을 X, Y, Z 축에서 제어하는 기능을 제공합니다.
    /// 특정 축에 회전을 추가하고, 회전 속도를 설정하며,
    /// 각 축의 회전 범위를 제한하는 메서드를 포함합니다.
    /// </summary>
    public interface IRotator : IModule
    {
        /// <summary>
        /// 회전할 축의 종류(X, Y, Z)를 정의합니다.
        /// </summary>
        enum AxisType
        {
            X, Y, Z
        }

        /// <summary>
        /// 지정된 축에 회전 요인을 추가합니다. 회전 요인은 양수 또는 음수일 수 있으며,
        /// 지정된 축을 기준으로 얼마나 회전할지를 결정합니다.
        /// </summary>
        /// <param name="axisType">회전이 적용될 축(X, Y, Z 중 하나).</param>
        /// <param name="factor">회전 요인 값. 양수 또는 음수로 회전 방향과 크기를 결정합니다.</param>
        void AddAxisRotation(AxisType axisType, float factor);
    }
}
