using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// 피로도 데이터를 관리하는 모델 인터페이스.
    /// </summary>
    public interface IFatigueModel
    {
        /// <summary>
        /// 피로도 설정 정보를 가져옵니다.
        /// </summary>
        IFatigueConfig Config { get; }

        /// <summary>
        /// 최대 피로도 값.
        /// </summary>
        float MaxFatigue { get; }

        /// <summary>
        /// 현재 피로도 값.
        /// </summary>
        float Fatigue { get; }

        /// <summary>
        /// 피로도 변화 시 호출되는 이벤트.
        /// </summary>
        event Action OnFatigueChanged;

        /// <summary>
        /// 피로도를 증가/감소시킵니다.
        /// </summary>
        void AddFatigue(float amount);
    }

}