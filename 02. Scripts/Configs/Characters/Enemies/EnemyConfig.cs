using GamePlay.Hubs;
using GamePlay.Modules;
using GamePlay.Modules.AI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// 적 캐릭터의 설정 데이터를 정의하는 클래스입니다.
    /// 다양한 모듈(공격, 방어, AI 등)과 상호작용하는 설정 값을 제공합니다.
    /// </summary>
    [Serializable]
    public class EnemyConfig : HubConfigBase, IDamageReceiverConfig, IEnemyAIConfig, IFollowerConfig,
        IDamageSenderConfig, ICombatStaterConfig, ICombatStaterModel, ITargetFinderConfig
    {
        public override string PrefabPath => $"Characters/Enemies/{_prefabPath}";

        [Header("----- 생성 정보 -----")]
        [SerializeField] string _materialPath = "Oni_Red";
        [SerializeField] float _scale = 1.0f;
        public string MaterialPath => $"Materials/{_materialPath}";
        public float Scale => _scale;

        [Header("----- 피격 -----")]
        [SerializeField] float _baseHealth = 100.0f;
        [SerializeField] CharacterTagType _characterTagType = CharacterTagType.Oni;
        float IDamageReceiverConfig.BaseHealth => _baseHealth;
        CharacterTagType IDamageReceiverConfig.CharacterTagType => _characterTagType;

        [Header("----- 공격 -----")]
        [SerializeField] float _baseDamage = 10.0f;

        float IDamageSenderConfig.BaseDamage => _baseDamage;
        IReadOnlyList<CharacterTagType> IDamageSenderConfig.TargetCharacterTagTypes => _targetTagTypes;

        [Header("----- 전투 -----")]

        [SerializeField] float _stiffenTime = 0.75f;
        [SerializeField] float _attackingTime = 1.8f;

        float ICombatStaterConfig.StiffenTime => _stiffenTime;
        float ICombatStaterConfig.AttackingTime => _attackingTime;
        ICombatStaterConfig ICombatStaterModel.Config => this;

        [Header("----- 목표 이동 -----")]
        [SerializeField] float _followerUpdateSpan = 0.2f;
        [SerializeField] float _baseAngularSpeed = 120.0f;

        float IFollowerConfig.UpdateSpan => _followerUpdateSpan;
        float IFollowerConfig.BaseAngularSpeed => _baseAngularSpeed;

        [Header("----- AI -----")]
        [SerializeField] float _updateSpan = 0.5f;
        [SerializeField] float _baseSpeed = 2;
        [SerializeField] string _idleBehaviourKey = "BasicPatrol";
        [SerializeField] string _traceBehaviourKey = "BasicTrace";
        [SerializeField] string _attackingBehaviourKey = "BasicAttacking";
        [SerializeField] float _detectionLength = 30.0f;
        [SerializeField] float _traceLength = 50.0f;
        [SerializeField] float _attackLength = 3.0f;
        [SerializeField] float _hitSphereRadius = 0.5f;

        float IAIConfig.UpdateSpan => _updateSpan;
        float IEnemyAIConfig.BaseSpeed => _baseSpeed;
        string IEnemyAIConfig.IdleBehaviourKey => _idleBehaviourKey;
        string IEnemyAIConfig.TraceBehaviourKey => _traceBehaviourKey;
        string IEnemyAIConfig.AttackingBehaviourKey => _attackingBehaviourKey;
        float IEnemyAIConfig.DetectionLength => _detectionLength;
        float IEnemyAIConfig.TraceLength => _traceLength;
        float IEnemyAIConfig.AttackLength => _attackLength;
        float IEnemyAIConfig.HitSphereRadius => _hitSphereRadius;

        [Header("----- 타겟 찾기 -----")]
        [SerializeField] LayerMask _targetLayerMask = 1 << 5;
        [SerializeField] CharacterTagType[] _targetTagTypes = new CharacterTagType[] { CharacterTagType.Hero };
        [SerializeField] int _detectionCountLimit = 10;
        LayerMask ITargetFinderConfig.TargetLayerMask => _targetLayerMask;
        IReadOnlyList<CharacterTagType> ITargetFinderConfig.TargetTags => _targetTagTypes;
        int ITargetFinderConfig.DetectionCountLimit => _detectionCountLimit;

        [Header("----- 사망 처리 -----")]
        [SerializeField] float _corpseDuration = 10.0f;
        public float CorpseDuration => _corpseDuration;

        public EnemyConfig()
        {
            _key = "Oni";
            _prefabPath = "Oni";
        }
    }
}