using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// 스프린트 기능의 런타임 데이터를 관리하는 인터페이스.
    /// </summary>
    public interface ISprinterModel
    {
        /// <summary>
        /// 스프린트 설정.
        /// </summary>
        ISprinterConfig Config { get; }

        /// <summary>
        /// 현재 스프린트 여부.
        /// </summary>
        bool IsSprinting { get; }

        /// <summary>
        /// 최대 스태미너 값.
        /// </summary>
        float MaxStamina { get; }

        /// <summary>
        /// 현재 스태미너 값.
        /// </summary>
        float Stamina { get; }

        /// <summary>
        /// 스태미너 값이 변경될 때 호출되는 이벤트.
        /// </summary>
        event Action OnStaminaChanged;

        /// <summary>
        /// 스프린트 상태를 설정합니다.
        /// </summary>
        /// <param name="isSprinting">스프린트 여부</param>
        void SetIsSprinting(bool isSprinting);

        /// <summary>
        /// 스태미너 값을 추가합니다.
        /// </summary>
        /// <param name="amount">추가할 스태미너 값</param>
        void AddStamina(float amount);
    }
}