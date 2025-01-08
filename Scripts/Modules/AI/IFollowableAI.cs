using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules.AI
{
    /// <summary>
    /// Ư�� ���(Transform �Ǵ� ��ġ)�� ���󰡴� AI�� ���� �������̽��Դϴ�.
    /// </summary>
    public interface IFollowableAI : IAI
    {
        /// <summary>AI�� ������ ��.</summary>
        IFollowableAIModel Model { get; }

        /// <summary>AI�� �ʱ� ���� ��ġ.</summary>
        Vector3 SpawnPosition { get; }

        /// <summary>Ư�� Transform�� ���󰩴ϴ�.</summary>
        /// <param name="target">���� ���.</param>
        void FollowTarget(Transform target);

        /// <summary>Ư�� ��ġ�� ���󰩴ϴ�.</summary>
        /// <param name="position">���� ��ġ.</param>
        void FollowPosition(Vector3 position);

        /// <summary>������ �����մϴ�.</summary>
        void Unfollow();
    }

    /// <summary>
    /// Ư�� ����� �����ϴ� AI�� ���� �������̽��Դϴ�.
    /// </summary>
    public interface ITargetFollowableAI : IFollowableAI
    {
        /// <summary>���� ���� ���� ����� Transform.</summary>
        Transform Target { get; }

        /// <summary>���� ����� ����� �� �߻��ϴ� �̺�Ʈ.</summary>
        event Action OnTargetChanged;
    }


    /// <summary>
    /// ���(Path)�� ���󰡴� AI�� ���� �������̽��Դϴ�.
    /// </summary>
    public interface IPathFollowableAI : IFollowableAI
    {
        /// <summary>������ ��� ����Ʈ.</summary>
        IReadOnlyList<Transform> Paths { get; }
    }
}


