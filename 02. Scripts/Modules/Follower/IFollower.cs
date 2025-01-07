using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// ���(Transform �Ǵ� ��ġ) ������ ���� ��� �������̽�.
    /// </summary>
    public interface IFollower : IModule
    {
        /// <summary>�ӵ� ���� �̺�Ʈ.</summary>
        event Action<Vector3> OnVelocityChanged;

        /// <summary>��� Transform ����.</summary>
        void SetTarget(Transform target);

        /// <summary>��� ��ġ(Vector3) ����.</summary>
        void SetTarget(Vector3 position);

        /// <summary>���� ����.</summary>
        void Stop();

        /// <summary>���� �Ͻ� ����/�簳.</summary>
        void Pause(bool isPause);
    }
}


