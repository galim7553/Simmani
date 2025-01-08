using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// �Ƿε� �����͸� �����ϴ� Ŭ����.
    /// </summary>
    [Serializable]
    public class FatigueData
    {
        [SerializeField] float _fatigue;
        /// <summary>
        /// ���� �Ƿε� ��.
        /// </summary>
        public float Fatigue => _fatigue;

        /// <summary>
        /// �Ƿε� ���� �����մϴ�.
        /// </summary>
        public void SetFatigue(float fatigue)
        {
            _fatigue = fatigue;
        }
    }
}


