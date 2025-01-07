using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay.Modules.AI
{
    /// <summary>
    /// AI의 기본 인터페이스로, 공통적인 AI 동작과 속성을 정의합니다.
    /// </summary>
    public interface IAI
    {
        /// <summary>AI를 구분하는 고유 키.</summary>
        string Key { get; }

        /// <summary>AI가 제어하는 Transform.</summary>
        Transform Transform { get; }

        /// <summary>AI에서 사용할 Coroutine Runner.</summary>
        ICoroutineRunner CoroutineRunner { get; }

        /// <summary>AI 상태 업데이트 간격.</summary>
        float UpdateSpan { get; }

        /// <summary>AI 동작을 시작합니다.</summary>
        void Start();

        /// <summary>AI 동작을 중지합니다.</summary>
        void Stop();

        /// <summary>AI 동작을 일시 정지하거나 다시 시작합니다.</summary>
        /// <param name="isPause">true이면 일시 정지, false이면 다시 시작.</param>
        void Pause(bool isPause);
    }
}


