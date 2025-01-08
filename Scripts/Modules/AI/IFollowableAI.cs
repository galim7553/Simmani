using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules.AI
{
    /// <summary>
    /// 특정 대상(Transform 또는 위치)을 따라가는 AI를 위한 인터페이스입니다.
    /// </summary>
    public interface IFollowableAI : IAI
    {
        /// <summary>AI의 데이터 모델.</summary>
        IFollowableAIModel Model { get; }

        /// <summary>AI의 초기 스폰 위치.</summary>
        Vector3 SpawnPosition { get; }

        /// <summary>특정 Transform을 따라갑니다.</summary>
        /// <param name="target">따라갈 대상.</param>
        void FollowTarget(Transform target);

        /// <summary>특정 위치를 따라갑니다.</summary>
        /// <param name="position">따라갈 위치.</param>
        void FollowPosition(Vector3 position);

        /// <summary>추적을 중지합니다.</summary>
        void Unfollow();
    }

    /// <summary>
    /// 특정 대상을 추적하는 AI를 위한 인터페이스입니다.
    /// </summary>
    public interface ITargetFollowableAI : IFollowableAI
    {
        /// <summary>현재 추적 중인 대상의 Transform.</summary>
        Transform Target { get; }

        /// <summary>추적 대상이 변경될 때 발생하는 이벤트.</summary>
        event Action OnTargetChanged;
    }


    /// <summary>
    /// 경로(Path)를 따라가는 AI를 위한 인터페이스입니다.
    /// </summary>
    public interface IPathFollowableAI : IFollowableAI
    {
        /// <summary>추적할 경로 리스트.</summary>
        IReadOnlyList<Transform> Paths { get; }
    }
}


