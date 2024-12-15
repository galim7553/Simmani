using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// ��� ȸ���� X, Y, Z �࿡�� �����ϴ� ����� �����մϴ�.
    /// Ư�� �࿡ ȸ���� �߰��ϰ�, ȸ�� �ӵ��� �����ϸ�,
    /// �� ���� ȸ�� ������ �����ϴ� �޼��带 �����մϴ�.
    /// </summary>
    public interface IRotator : IModule
    {
        /// <summary>
        /// ȸ���� ���� ����(X, Y, Z)�� �����մϴ�.
        /// </summary>
        enum AxisType
        {
            X, Y, Z
        }

        /// <summary>
        /// ������ �࿡ ȸ�� ������ �߰��մϴ�. ȸ�� ������ ��� �Ǵ� ������ �� ������,
        /// ������ ���� �������� �󸶳� ȸ�������� �����մϴ�.
        /// </summary>
        /// <param name="axisType">ȸ���� ����� ��(X, Y, Z �� �ϳ�).</param>
        /// <param name="factor">ȸ�� ���� ��. ��� �Ǵ� ������ ȸ�� ����� ũ�⸦ �����մϴ�.</param>
        void AddAxisRotation(AxisType axisType, float factor);
    }
}
