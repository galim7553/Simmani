namespace GamePlay.Modules
{
    /// <summary>
    /// 추적 동작에 대한 설정 인터페이스.
    /// </summary>
    public interface IFollowerConfig
    {
        /// <summary>업데이트 주기.</summary>
        float UpdateSpan { get; }

        /// <summary>기본 회전 속도.</summary>
        float BaseAngularSpeed { get; }
    }
}


