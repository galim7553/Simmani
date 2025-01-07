using GamePlay.Configs;

namespace GamePlay.Modules.AI
{
    /// <summary>
    /// AI의 설정값을 정의하는 인터페이스입니다.
    /// </summary>
    public interface IAIConfig : IConfig
    {

        /// <summary>AI 상태 업데이트 간격.</summary>
        float UpdateSpan { get; }
    }
}


