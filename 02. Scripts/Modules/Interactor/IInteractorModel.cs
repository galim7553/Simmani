using GamePlay.Commands;

namespace GamePlay.Modules
{
    /// <summary>
    /// ��ȣ�ۿ���(Interactor)�� ������ �� �������̽�.
    /// </summary>
    public interface IInteractorModel
    {
        /// <summary>���� ��ȣ�ۿ� ����� ��Ÿ��.</summary>
        ICommand Command { get; }
    }
}