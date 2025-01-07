namespace GamePlay.Modules
{
    /// <summary>
    /// 스프린트 기능을 제공하는 모듈의 인터페이스.
    /// </summary>
    public interface ISprinter : IModule
    {
        /// <summary>
        /// 스프린트 상태를 설정합니다.
        /// </summary>
        /// <param name="isSprinting">스프린트 여부</param>
        void SetIsSprinting(bool isSprinting);
    }
}
