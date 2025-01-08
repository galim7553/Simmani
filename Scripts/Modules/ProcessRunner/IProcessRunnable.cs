using System;
using GamePlay.Modules;

namespace GamePlay
{
    /// <summary>
    /// ó�� ���� ������ ��ü�� �����ϴ� �������̽��Դϴ�.
    /// </summary>
    public interface IProcessRunnable
    {
        /// <summary>
        /// �۾� ���� ���� ���θ� ��ȯ�մϴ�.
        /// </summary>
        bool IsProcessRunnable { get; }

        /// <summary>
        /// �۾��� �����մϴ�.
        /// </summary>
        /// <param name="processable">ó�� ������ �۾�</param>
        void BeginProcess(IProcessable processable);

        /// <summary>
        /// �ܺ� ����� �Բ� �۾��� �����մϴ�.
        /// </summary>
        /// <param name="processable">ó�� ������ �۾�</param>
        /// <param name="onEnded">�۾� ���� �� ȣ��Ǵ� �׼�</param>
        void BeginProcessWithExternalControl(IProcessable processable, out Action onEnded);
    }
}


