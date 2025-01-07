using System;
using GamePlay.Modules;
using GamePlay.Modules.AI;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// 행인(Passenger) 캐릭터의 설정 정보를 정의하는 클래스입니다.
    /// 상호작용, AI, 목표 이동과 관련된 설정 값을 제공합니다.
    /// </summary>
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

        float IFollowerConfig.UpdateSpan => _followerUpdateSpan;
        float IFollowerConfig.BaseAngularSpeed => _baseAngularSpeed;

        [Header("----- AI -----")]
        [SerializeField] float _updateSpan = 0.5f;
        [SerializeField] float _baseSpeed = 1.0f;
        [SerializeField] string _behaviourKey = "PathFollowing_0";
        float IAIConfig.UpdateSpan => _updateSpan;
        float IPassengerAIConfig.BaseSpeed => _baseSpeed;
        string IPassengerAIConfig.BehaviourKey => _behaviourKey;


    }
}


