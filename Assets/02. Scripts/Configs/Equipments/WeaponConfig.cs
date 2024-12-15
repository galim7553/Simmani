using GamePlay.Hubs;
using GamePlay.Hubs.Equipments;
using GamePlay.Modules;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Configs
{
    [Serializable]
    public class WeaponConfig : EquipmentConfig, IDamageSenderConfig
    {
        public override string PrefabPath => $"Equipments/Weapons/{_prefabPath}";
        public override EquipType EquipType => EquipType.Weapon;

        [Header("----- ¹«±â -----")]
        [SerializeField] float _baseDamage = 10.0f;
        [SerializeField] CharacterTagType[] _targetCharacterTagTypes = new CharacterTagType[] { CharacterTagType.Oni, CharacterTagType.Tiger };

        float IDamageSenderConfig.BaseDamage => _baseDamage;
        IReadOnlyList<CharacterTagType> IDamageSenderConfig.TargetCharacterTagTypes => _targetCharacterTagTypes;
    }

}

