using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Modules;
using GamePlay.Modules.AI;
using UnityEngine;

namespace GamePlay.Configs
{
    [Serializable]
    public class PassengerConfig : HubConfigBase, IInteractorConfig, IPassengerAIConfig, IFollowerConfig
    {
        public override string PrefabPath => $"Characters/Villagers/{_prefabPath}";

        [Header("----- 상호작용 -----")]
        [SerializeField] string _commandKey = "TestConversation";
        public string CommandKey => _commandKey;

        [Header("----- 목표 이동 -----")]
        [SerializeField] float _followerUpdateSpan = 0.2f;
        [SerializeField] float _baseAngularSpeed = 120.0f;
        [SerializeField] float _baseRotSpeed = 5.0f;

        float IFollowerConfig.UpdateSpan => _followerUpdateSpan;
        float IFollowerConfig.BaseAngularSpeed => _baseAngularSpeed;
        float IFollowerConfig.BaseRotSpeed => _baseRotSpeed;

        [Header("----- AI -----")]
        [SerializeField] float _updateSpan = 0.5f;
        [SerializeField] float _baseSpeed = 1.0f;
        [SerializeField] string _behaviourKey = "PathFollowing_0";
        float IAIConfig.UpdateSpan => _updateSpan;
        float IPassengerAIConfig.BaseSpeed => _baseSpeed;
        string IPassengerAIConfig.BehaviourKey => _behaviourKey;


    }
}


