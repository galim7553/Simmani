using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules.AI
{
    public interface IFollowableAI : IAI
    {
        IFollowableAIModel Model { get; }
        Vector3 SpawnPosition { get; }
        void FollowTarget(Transform target);
        void FollowPosition(Vector3 position);
        void Unfollow();
    }

    public interface ITargetFollowableAI : IFollowableAI
    {
        Transform Target { get; }
        event Action OnTargetChanged;
    }


    public interface IPathFollowableAI : IFollowableAI
    {
        IReadOnlyList<Transform> Paths { get; }
    }
}


