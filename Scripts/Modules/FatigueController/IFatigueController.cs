using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// �Ƿε��� �����ϴ� ��� �������̽�.
    /// </summary>
    public interface IFatigueController : IModule
    {
        /// <summary>
        /// �Ƿε��� 0�� �� �� ȣ��Ǵ� �̺�Ʈ.
        /// </summary>
        event Action OnFatigueEmpty;
    }

}

