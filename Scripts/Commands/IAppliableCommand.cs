namespace GamePlay.Commands
{
    /// <summary>
    /// 특정 대상에 적용 가능한 명령 인터페이스.
    /// </summary>
    /// <typeparam name="T">명령을 적용할 대상 타입.</typeparam>
    public interface IAppliableCommand<T> : ICommand
    {
        /// <summary>
        /// 대상에 명령을 적용합니다.
        /// </summary>
        /// <param name="target">명령을 적용할 대상.</param>
        void Apply(T target);


        /// <summary>
        /// 대상에서 명령을 해제합니다.
        /// </summary>
        /// <param name="target">명령을 해제할 대상.</param>
        void Disapply(T target);
    }
}


