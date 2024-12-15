using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Modules.AI;
using UnityEngine;

namespace GamePlay.Configs
{
    [Serializable]
    public class AttackingBehaviourConfig : ConfigBase, IAttackingBehaviourConfig
    {
        [Header("----- ���� �ൿ -----")]
        [SerializeField] float _span = 2.0f;
        [SerializeField] float _angleThreshold = 30.0f;
        [SerializeField] float _rotSpeed = 50.0f;
        public float Span => _span;
        public float AngleThreshold => _angleThreshold;
        public float RotSpeed => _rotSpeed;
    }
    [Serializable]
    public class TraceBehaviourConfig : ConfigBase, ITraceBehaviourConfig
    {
        [Header("----- ���� �ൿ -----")]
        [SerializeField] float _speedRatio = 1.5f;
        public float SpeedRatio => _speedRatio;
    }
    [Serializable]
    public class PatrolBehaviourConfig : ConfigBase, IPatrolBehaviourConfig
    {
        [Header("----- ���� �ൿ -----")]
        [SerializeField] float _minRadius = 5.0f;
        [SerializeField] float _maxRadius = 10.0f;
        [SerializeField] float _minSpan = 10.0f;
        [SerializeField] float _maxSpan = 20.0f;
        [SerializeField] float _speedRatio = 1.0f;
        public float MinRadius => _minRadius;
        public float MaxRadius => _maxRadius;
        public float MinSpan => _minSpan;
        public float MaxSpan => _maxSpan;
        public float SpeedRatio => _speedRatio;
    }
    [Serializable]
    public class ReturnToSpawnBehaivourConfig : ConfigBase, IReturnToSpawnBehaviourConfig
    {
        [Header("----- ���� �ൿ -----")]
        [SerializeField] float _speedRatio = 1.0f;
        public float SpeedRatio => _speedRatio;
    }

    [Serializable]
    public class PathFollowingBehaviourConfig : ConfigBase, IPathFollowingBehaviourConfig
    {
        [Header("---- ��� ��ȸ �ൿ -----")]
        [SerializeField] IPathFollowingBehaviourConfig.LoopType _loopType = IPathFollowingBehaviourConfig.LoopType.PingPongLoop;
        [SerializeField] float _speedRatio = 1.0f;
        [SerializeField] float _brakingDistance = 1.0f;
        public IPathFollowingBehaviourConfig.LoopType Type => _loopType;
        public float SpeedRatio => _speedRatio;
        public float BrakingDistance => _brakingDistance;
    }
}