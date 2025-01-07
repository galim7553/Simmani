using System.Collections.Generic;
using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 타겟 탐지 설정 인터페이스.
    /// </summary>
    public interface ITargetFinderConfig
    {
        /// <summary>탐지 대상의 레이어 마스크.</summary>
        LayerMask TargetLayerMask { get; }

        /// <summary>탐지 가능한 타겟 태그 목록.</summary>
        IReadOnlyList<CharacterTagType> TargetTags { get; }

        /// <summary>탐지 가능한 최대 대상 수.</summary>
        int DetectionCountLimit { get; }
    }
}