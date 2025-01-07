using System;
using UnityEngine;

namespace GamePlay.Hubs.Equipments
{

    /// <summary>
    /// �ִϸ����� ���̾� ���� Ŭ����.
    /// </summary>
    [Serializable]
    public class AnimatorLayerInfo
    {
        [SerializeField] int _targetLayerIndex;
        [SerializeField] float _weight;

        /// <summary>
        /// �ִϸ����� ���̾� �ε���.
        /// </summary>
        public int TargetLayerIndex => _targetLayerIndex;

        /// <summary>
        /// �ִϸ����� ���̾� ����ġ.
        /// </summary>
        public float Weight => _weight;
    }
}