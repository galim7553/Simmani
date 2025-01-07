namespace GamePlay.Modules
{
    /// <summary>
    /// 상호작용자(Interactor)의 설정값 인터페이스.
    /// </summary>
    public interface IInteractorConfig
    {
        /// <summary>상호작용에 사용할 명령의 키.</summary>
        string CommandKey { get; }
    }

}

