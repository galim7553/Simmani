using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// 피로도를 제어하는 모듈 인터페이스.
    /// </summary>
    public interface IFatigueController : IModule
    {
        /// <summary>
        /// 피로도가 0이 될 때 호출되는 이벤트.
        /// </summary>
        event Action OnFatigueEmpty;
    }

}

