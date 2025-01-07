using System;
using UnityEngine;

namespace GamePlay.Modules.AI
{
    /// <summary>
    /// ���� ������ AI�� ���۰� �̺�Ʈ�� �����ϴ� �������̽��Դϴ�.
    /// </summary>
    public interface IAttackableAI : IAI
    {
        /// <summary>���� ���� ����� Transform.</summary>
        Transform Target { get; }

        /// <summary>AI�� �Ͻ� ���� ���¸� ��Ÿ���ϴ�.</summary>
        bool IsPaused { get; }

        /// <summary>AI�� ȸ���� �� �߻��ϴ� �̺�Ʈ.</summary>
        event Action<float> OnRotated;

        /// <summary>AI�� ������ �����մϴ�.</summary>
        void Attack();

        /// <summary>ȸ�� �̺�Ʈ�� �߻���ŵ�ϴ�.</summary>
        /// <param name="speed">ȸ�� �ӵ�.</param>
        void InvokeRotatedEvent(float speed);
        
    }
}


