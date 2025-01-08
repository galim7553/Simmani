using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Presenters
{
    /// <summary>
    /// ��Ű �׷� ���� �������̽�.
    /// </summary>
    public interface IHotKeyGroupConfig
    {
        /// <summary>
        /// ��Ű ������ ���� ����Ʈ.
        /// </summary>
        IReadOnlyList<HotKeyInfo> HotKeyInfos { get; }
    }

    /// <summary>
    /// ���� ��Ű ������ ��� Ŭ����.
    /// </summary>
    [Serializable]
    public class HotKeyInfo
    {
        [SerializeField] string _targetItemKey = "Red_Potion";
        [SerializeField] string _spritePath = "Red";

        /// <summary>
        /// Ÿ�� ������ Ű.
        /// </summary>
        public string TargetItemKey => _targetItemKey;

        /// <summary>
        /// ��Ű ������ ��������Ʈ ���.
        /// </summary>
        public string SpritePath => $"Sprites/Items/{_spritePath}";
    }
}


