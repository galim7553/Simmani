using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// ��ȣ�ۿ� ������ �������̽�.
    /// </summary>
    public interface IInteractorDetector : IModule
    {
        /// <summary>��ȣ�ۿ� ������ ��ü�� �������� �� ȣ��Ǵ� �̺�Ʈ.</summary>
        event Action<IInteractor> OnInteractorDetected;

        /// <summary>��ȣ�ۿ� ������ ��ü�� �������� ������ �� ȣ��Ǵ� �̺�Ʈ.</summary>
        event Action OnInteractorMissed;
    }
}


