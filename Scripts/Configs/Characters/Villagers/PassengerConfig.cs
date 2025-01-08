using System;
using GamePlay.Modules;
using GamePlay.Modules.AI;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// ����(Passenger) ĳ������ ���� ������ �����ϴ� Ŭ�����Դϴ�.
    /// ��ȣ�ۿ�, AI, ��ǥ �̵��� ���õ� ���� ���� �����մϴ�.
    /// </summary>
    [Serializable]
    public class PassengerConfig : HubConfigBase, IInteractorConfig, IPassengerAIConfig, IFollowerConfig
    {
        public override string PrefabPath => $"Characters/Villagers/{_prefabPath}";

        [Header("----- ��ȣ�ۿ� -----")]
        [SerializeField] string _commandKey = "TestConversation";
        public string CommandKey => _commandKey;

        [Header("----- ��ǥ �̵� -----")]
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


