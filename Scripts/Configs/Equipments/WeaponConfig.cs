using GamePlay.Hubs;
using GamePlay.Hubs.Equipments;
using GamePlay.Modules;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// 무기(Weapon)의 설정값을 정의하는 클래스.
    /// </summary>
    [Serializable]
    public class WeaponConfig : EquipmentConfig, IDamageSenderConfig
    {
        public override string PrefabPath => $"Equipments/Weapons/{_prefabPath}";
        public override EquipType EquipType => EquipType.Weapon;

        [Header("----- 무기 -----")]
        [SerializeField] float _baseDamage = 10.0f;
        [SerializeField] CharacterTagType[] _targetCharacterTagTypes = new CharacterTagType[] { CharacterTagType.Oni, CharacterTagType.Tiger };

        /// <summary>
        /// 무기의 기본 공격력.
        /// </summary>
        float IDamageSenderConfig.BaseDamage => _baseDamage;

        /// <summary>
        /// 공격 가능한 대상의 태그 유형.
        /// </summary>
        IReadOnlyList<CharacterTagType> IDamageSenderConfig.TargetCharacterTagTypes => _targetCharacterTagTypes;
    }

}

