using System;
using GamePlay.Modules.AI;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// 공격 행동 설정 클래스. 공격 간격, 회전 속도, 각도 제한을 정의합니다.
    /// </summary>
    [Serializable]
    public class AttackingBehaviourConfig : ConfigBase, IAttackingBehaviourConfig
    {
        [Header("----- 공격 행동 -----")]
        [SerializeField] float _span = 2.0f;
        [SerializeField] float _angleThreshold = 30.0f;
        [SerializeField] float _rotSpeed = 50.0f;
        public float Span => _span;
        public float AngleThreshold => _angleThreshold;
        public float RotSpeed => _rotSpeed;
    }

    /// <summary>
    /// 추적 행동 설정 클래스. 추적 속도 비율을 정의합니다.
    /// </summary>
    [Serializable]
    public class TraceBehaviourConfig : ConfigBase, ITraceBehaviourConfig
    {
        [Header("----- 추적 행동 -----")]
        [SerializeField] float _speedRatio = 1.5f;
        public float SpeedRatio => _speedRatio;
    }

    /// <summary>
    /// 순찰 행동 설정 클래스. 순찰 범위, 간격, 속도를 정의합니다.
    /// </summary>
    [Serializable]
    public class PatrolBehaviourConfig : ConfigBase, IPatrolBehaviourConfig
    {
        [Header("----- 순찰 행동 -----")]
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

    /// <summary>
    /// 복귀 행동 설정 클래스. 복귀 속도를 정의합니다.
    /// </summary>
    [Serializable]
    public class ReturnToSpawnBehaivourConfig : ConfigBase, IReturnToSpawnBehaviourConfig
    {
        [Header("----- 복귀 행동 -----")]
        [SerializeField] float _speedRatio = 1.0f;
        public float SpeedRatio => _speedRatio;
    }

    /// <summary>
    /// 경로 순회 행동 설정 클래스. 순회 방식, 속도 비율, 감속 거리를 정의합니다.
    /// </summary>
    [Serializable]
    public class PathFollowingBehaviourConfig : ConfigBase, IPathFollowingBehaviourConfig
    {
        [Header("---- 경로 순회 행동 -----")]
        [SerializeField] IPathFollowingBehaviourConfig.LoopType _loopType = IPathFollowingBehaviourConfig.LoopType.PingPongLoop;
        [SerializeField] float _speedRatio = 1.0f;
        [SerializeField] float _brakingDistance = 1.0f;
        public IPathFollowingBehaviourConfig.LoopType Type => _loopType;
        public float SpeedRatio => _speedRatio;
        public float BrakingDistance => _brakingDistance;
    }
}