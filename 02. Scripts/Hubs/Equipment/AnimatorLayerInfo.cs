using System;
using UnityEngine;

namespace GamePlay.Hubs.Equipments
{

    /// <summary>
    /// 애니메이터 레이어 정보 클래스.
    /// </summary>
    [Serializable]
    public class AnimatorLayerInfo
    {
        [SerializeField] int _targetLayerIndex;
        [SerializeField] float _weight;

        /// <summary>
        /// 애니메이터 레이어 인덱스.
        /// </summary>
        public int TargetLayerIndex => _targetLayerIndex;

        /// <summary>
        /// 애니메이터 레이어 가중치.
        /// </summary>
        public float Weight => _weight;
    }
}