using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// �۾� ������ �����ϴ� ��� �������̽��Դϴ�.
    /// </summary>
    public interface IProcessRunner : IModule
    {
        /// <summary>
        /// �۾� ���� �� �߻��ϴ� �̺�Ʈ�Դϴ�.
        /// </summary>
        event Action OnBegan;

        /// <summary>
        /// �۾� ���� �� ȣ��Ǵ� �̺�Ʈ�Դϴ�.
        /// ������� �����մϴ�.
        /// </summary>
        event Action<float> OnProcess;

        /// <summary>
        /// �۾� ���� �� �߻��ϴ� �̺�Ʈ�Դϴ�.
        /// </summary>
        event Action OnEnded;

        /// <summary>
        /// ���� �۾� ���� ���¸� ��ȯ�մϴ�.
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// �۾��� �����մϴ�.
        /// </summary>
        /// <param name="processable">ó�� ������ �۾�</param>
        void Begin(IProcessable processable);

        /// <summary>
        /// �ܺ� ����� �Բ� �۾��� �����մϴ�.
        /// </summary>
        /// <param name="processable">ó�� ������ �۾�</param>
        void BeginWithExternalControl(IProcessable processable);

        /// <summary>
        /// �۾��� ���з� �����մϴ�.
        /// </summary>
        void Fail();

        /// <summary>
        /// �۾��� ���������� �����մϴ�.
        /// </summary>
        void End();
    }
}

