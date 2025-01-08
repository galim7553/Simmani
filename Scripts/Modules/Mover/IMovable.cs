using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// �̵� ������ ��ü�� ���� �̵� ������ �����ϴ� �������̽�.
    /// </summary>
    public interface IMovable
    {
        /// <summary>
        /// �Է� ���͸� ������� ��ü�� �̵��մϴ�.
        /// </summary>
        /// <param name="inputVector">�̵� ���� �� ũ�⸦ ��Ÿ���� 2D ����</param>
        void Move(Vector2 inputVector);
    }
}