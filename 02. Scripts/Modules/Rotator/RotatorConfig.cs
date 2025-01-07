using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// ȸ�� ����� ���� �����͸� ������ Ŭ����.
    /// </summary>
    [Serializable]
    public class RotatorConfig : IRotatorModel
    {
        [SerializeField] float _baseRotSpeed;
        [SerializeField] RotatorLimiter _rotatorLimiter = new RotatorLimiter();

        /// <summary>
        /// ȸ�� �ӵ�.
        /// </summary>
        float IRotatorModel.RotSpeed => _baseRotSpeed;

        /// <summary>
        /// ȸ�� ���� ������.
        /// </summary>
        RotatorLimiter IRotatorModel.RotatorLimiter => _rotatorLimiter;
    }
}