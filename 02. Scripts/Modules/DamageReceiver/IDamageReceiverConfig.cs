using GamePlay.Hubs;

namespace GamePlay.Modules
{
    /// <summary>
    /// 피격 시스템의 설정값을 정의하는 인터페이스.
    /// </summary>
    public interface IDamageReceiverConfig
    {
        /// <summary>
        /// 캐릭터의 태그 타입.
        /// </summary>
        CharacterTagType CharacterTagType { get; }

        /// <summary>
        /// 캐릭터의 기본 체력.
        /// </summary>
        float BaseHealth { get; }
    }
}