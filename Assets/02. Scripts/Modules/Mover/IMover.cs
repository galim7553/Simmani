using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// ĳ������ �̵��� ó���ϴ� ����� �����ϴ� �������̽��Դϴ�.
    /// �̵� ���� ����, �̵� �ӵ� ����, �̵� ���� ���� �̺�Ʈ�� �����մϴ�.
    /// </summary>
    public interface IMover : IModule
    {
        float Speed { get; }
        event Action<Vector3> OnDirectionChanged;

        /// <summary>
        /// ĳ������ �̵� ������ �����մϴ�. �� ��(x, y, z)���� �̵��� ���� �Է��մϴ�.
        /// </summary>
        /// <param name="x">X�� �̵� ���� ��</param>
        /// <param name="y">Y�� �̵� ���� ��</param>
        /// <param name="z">Z�� �̵� ���� ��</param>
        void SetDirection(float x, float y, float z);
    }
}