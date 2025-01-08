using GamePlay.Modules;

namespace GamePlay.Commands
{
    /// <summary>
    /// 산삼 명령 설정 인터페이스.
    /// </summary>
    public interface ISansamCommandConfig : ICommandConfig
    {
        /// <summary>프로세스에 필요한 시간.</summary>
        float ProcessAmount { get; }

        /// <summary>프로세스 유형.</summary>
        IProcessable.ProcessType ProcessType { get; }

        /// <summary>산삼 아이템 키.</summary>
        string SansamItemKey { get; }

        /// <summary>산삼이 아닐 때의 아이템 키.</summary>
        string NotSansamItemKey { get;}
    }
}


