using GamePlay.Hubs;
using GamePlay.Hubs.Equipments;
using GamePlay.Modules;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// ����(Weapon)�� �������� �����ϴ� Ŭ����.
    /// </summary>
    [Serializable]
    public class WeaponConfig : EquipmentConfig, IDamageSenderConfig
    {
        public override string PrefabPath => $"Equipments/Weapons/{_prefabPath}";
        public override EquipType EquipType => EquipType.Weapon;

        [Header("----- ���� -----")]
        [SerializeField] float _baseDamage = 10.0f;
        [SerializeField] CharacterTagType[] _targetCharacterTagTypes = new CharacterTagType[] { CharacterTagType.Oni, CharacterTagType.Tiger };

        /// <summary>
        /// ������ �⺻ ���ݷ�.
        /// </summary>
        float IDamageSenderConfig.BaseDamage => _baseDamage;

        /// <summary>
        /// ���� ������ ����� �±� ����.
        /// </summary>
        IReadOnlyList<CharacterTagType> IDamageSenderConfig.TargetCharacterTagTypes => _targetCharacterTagTypes;
    }

}

