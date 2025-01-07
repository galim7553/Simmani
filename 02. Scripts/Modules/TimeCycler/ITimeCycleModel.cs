using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// 게임 내 시간 주기 로직을 구현하는 인터페이스.
    /// </summary>
    public interface ITimeCycleModel
    {
        ITimeCycleConfig Config { get; }

        /// <summary>현재 게임 시각.</summary>
        DateTime DateTime { get; }

        /// <summary>게임 경과 일수.</summary>
        int GameDay { get; }

        /// <summary>한국 전통 시간 (2시간 단위).</summary>
        int KoreanHour { get; }

        /// <summary>게임 일수를 표시할 텍스트 키.</summary>
        string GameDayTextKey { get; }

        /// <summary>한국 전통 시간을 표시할 텍스트 키.</summary>
        string KoreanHourTextKey { get; }

        /// <summary>한국 전통 시간의 스프라이트 경로.</summary>
        string KoreanHourSpritePath { get; }

        /// <summary>시간이 변경될 때 발생하는 이벤트.</summary>
        event Action OnHourChanged;

        /// <summary>
        /// 시간 데이터를 업데이트.
        /// </summary>
        /// <param name="deltaTime">프레임 간 경과 시간.</param>
        void OnUpdate(float deltaTime);
    }
}