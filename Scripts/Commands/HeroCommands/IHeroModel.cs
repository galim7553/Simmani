namespace GamePlay.Commands
{
    /// <summary>
    /// Hero 모델이 실행 가능한 명령을 처리하는 인터페이스.
    /// </summary>
    public interface IHeroModel
    {
        /// <summary>
        /// 주어진 명령 타입과 값으로 Hero 모델에서 명령을 실행.
        /// </summary>
        /// <param name="commandType">명령의 타입.</param>
        /// <param name="amount">명령 값.</param>
        void ExecuteCommand(IHeroModelCommandConfig.CommandType commandType, float amount);
    }
}


