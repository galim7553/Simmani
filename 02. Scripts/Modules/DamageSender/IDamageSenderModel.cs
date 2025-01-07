using GamePlay.Hubs;

namespace GamePlay.Modules
{
    /// <summary>
    /// 데미지 송출자의 모델을 정의하는 인터페이스.
    /// </summary>
    public interface IDamageSenderModel
    {
        /// <summary>
        /// 현재 데미지 값.
        /// </summary>
        float Damage {  get; }

        /// <summary>
        /// 특정 캐릭터 태그에 대해 데미지 송출 가능 여부를 반환.
        /// </summary>
        /// <param name="characterTagType">확인할 캐릭터 태그 타입.</param>
        /// <returns>데미지 송출 가능 여부.</returns>
        bool GetIsDamageSendable(CharacterTagType characterTagType);
    }
}


