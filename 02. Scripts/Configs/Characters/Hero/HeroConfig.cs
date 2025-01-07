using GamePlay.Hubs;
using GamePlay.Hubs.Equipments;
using GamePlay.Modules;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// 플레이어 캐릭터(Hero)의 설정 데이터를 정의합니다.
    /// </summary>
    [Serializable]
    public class HeroConfig : HubConfigBase, IValidatableConfig, IDamageReceiverConfig, IEquipperConfig,
        IMoverModel, IJumperModel, ICombatStaterConfig, ICombatStaterModel, IFatigueConfig, ISprinterConfig
    {
        public override string PrefabPath => $"Characters/{_prefabPath}";

        [Header("----- 이동 -----")]
        [SerializeField] float _baseSpeed = 2.5f;
        float IMoverModel.Speed => _baseSpeed;

        [Header("----- 회전 -----")]
        [SerializeField] RotatorConfig _rotatorConfig;
        public RotatorConfig RotatorConfig => _rotatorConfig;

        [SerializeField] RotatorConfig _cameraRotatorConfig;
        public RotatorConfig CameraRotatorConfig => _cameraRotatorConfig;

        [Header("----- 점프 -----")]

        [SerializeField] float _baseJumpHeight = 0.7f;
        IJumper.JumpType IJumperModel.JumpType => IJumper.JumpType.Height;
        float IJumperModel.JumpHeight => _baseJumpHeight;
        float IJumperModel.JumpSpeed => 0;
        

        [Header("----- 피격 -----")]
        [SerializeField] float _baseHealth = 100.0f;
        [SerializeField] CharacterTagType _characterTagType = CharacterTagType.Hero;
        float IDamageReceiverConfig.BaseHealth => _baseHealth;
        CharacterTagType IDamageReceiverConfig.CharacterTagType => _characterTagType;

        [Header("----- 전투 -----")]
        [SerializeField] float _stiffenTime = 0.5f;
        [SerializeField] float _attackingTime = 0.8f;

        float ICombatStaterConfig.StiffenTime => _stiffenTime;
        float ICombatStaterConfig.AttackingTime => _attackingTime;
        ICombatStaterConfig ICombatStaterModel.Config => this;


        [Header("----- 장비 -----")]
        [SerializeField] List<EquipSlot> _equipSlots;
        IEnumerable<EquipSlot> IEquipperConfig.EquipSlots => _equipSlots;



        [Header("----- 피로도 -----")]
        [SerializeField] float _fatigue = 100.0f;
        [SerializeField] float _fatigueConsumptionSpeed = 0.36f;
        float IFatigueConfig.Fatigue => _fatigue;
        float IFatigueConfig.FatigueConsumptionSpeed => _fatigueConsumptionSpeed;

        [Header("----- 스프린트 -----")]
        [SerializeField] float _sprintSpeed = 5.0f;
        [SerializeField] float _stamina = 100.0f;
        [SerializeField] float _staminaConsumptionSpeed = 20.0f;
        [SerializeField] float _staminaRecoverySpeed = 5.0f;

        float ISprinterConfig.SprintSpeed => _sprintSpeed;
        float ISprinterConfig.Stamina => _stamina;
        float ISprinterConfig.StaminaConsumptionSpeed => _staminaConsumptionSpeed;
        float ISprinterConfig.StaminaRecoverySpeed => _staminaRecoverySpeed;




        public event Action OnValidated;
        public void InvokeOnValidatedEvent()
        {
            OnValidated?.Invoke();
        }
    }
}
