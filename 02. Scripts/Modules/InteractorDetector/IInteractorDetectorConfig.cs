using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 상호작용 감지기의 설정값 인터페이스.
    /// </summary>
    public interface IInteractorDetectorConfig
    {
        /// <summary>감지 레이의 최대 거리.</summary>
        float RayDistance { get; }

        /// <summary>감지 가능한 상호작용 가능한 레이어 마스크.</summary>
        LayerMask InteractableLayerMask { get; }
    }
}


