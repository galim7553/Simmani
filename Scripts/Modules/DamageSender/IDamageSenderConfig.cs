using System.Collections.Generic;
using GamePlay.Hubs;

namespace GamePlay.Modules
{
    /// <summary>
    /// 데미지 송출자의 설정값을 정의하는 인터페이스.
    /// </summary>
    public interface IDamageSenderConfig
    {
        /// <summary>
        /// 기본 데미지 값.
        /// </summary>
        float BaseDamage { get; }

        /// <summary>
        /// 데미지를 줄 수 있는 대상의 태그 타입 목록.
        /// </summary>
        IReadOnlyList<CharacterTagType> TargetCharacterTagTypes { get; }
    }
}