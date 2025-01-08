using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Presenters
{
    /// <summary>
    /// 핫키 그룹 설정 인터페이스.
    /// </summary>
    public interface IHotKeyGroupConfig
    {
        /// <summary>
        /// 핫키 정보를 담은 리스트.
        /// </summary>
        IReadOnlyList<HotKeyInfo> HotKeyInfos { get; }
    }

    /// <summary>
    /// 개별 핫키 정보를 담는 클래스.
    /// </summary>
    [Serializable]
    public class HotKeyInfo
    {
        [SerializeField] string _targetItemKey = "Red_Potion";
        [SerializeField] string _spritePath = "Red";

        /// <summary>
        /// 타겟 아이템 키.
        /// </summary>
        public string TargetItemKey => _targetItemKey;

        /// <summary>
        /// 핫키 아이콘 스프라이트 경로.
        /// </summary>
        public string SpritePath => $"Sprites/Items/{_spritePath}";
    }
}


