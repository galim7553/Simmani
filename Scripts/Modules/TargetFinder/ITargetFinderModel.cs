using GamePlay.Hubs;

namespace GamePlay.Modules
{
    /// <summary>
    /// 타겟 탐지 모델 인터페이스.
    /// </summary>
    public interface ITargetFinderModel
    {
        ITargetFinderConfig Config { get; }

        /// <summary>특정 태그가 타겟에 해당하는지 확인.</summary>
        bool GetIsTargetTag(CharacterTagType tagType);

        /// <summary>특정 태그의 우선순위를 가져옴.</summary>
        int GetTagPriority(CharacterTagType tagType);
        
    }

}

