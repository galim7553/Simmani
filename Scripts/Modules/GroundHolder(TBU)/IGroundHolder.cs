using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// ����(Terrain, Collider ��)�� ó���ϴ� ����� �����ϴ� �������̽��Դϴ�.
    /// </summary>
    /// <typeparam name="T">���� Ÿ��(Terrain, Collider ��)</typeparam>
    public interface IGroundHolder<T> : IModule
    {
        /// <summary>
        /// ������ �����մϴ�.
        /// ���׸� Ÿ�� T�� ������ �޾� ó���մϴ�.
        /// </summary>
        /// <param name="ground">������ ���� ��ü</param>
        void SetGround(T ground);

        /// <summary>
        /// ������� ������� ������ ���� �������� �����մϴ�.
        /// </summary>
        /// <param name="offset">������ ��</param>
        void SetOffset(float offset);

        /// <summary>
        /// ���� ������Ʈ�� ��ġ�� �������� �������� �ڵ����� ����ϰ� �����մϴ�.
        /// </summary>
        float SetOffsetAuto();
    }
}

