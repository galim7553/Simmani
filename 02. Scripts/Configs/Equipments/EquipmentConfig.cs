using GamePlay.Hubs.Equipments;
using System;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// ��� �������� �����ϴ� �߻� Ŭ����.
    /// </summary>
    [Serializable]
    public abstract class EquipmentConfig : HubConfigBase, IValidatableConfig
    {
        public override string PrefabPath => $"Equipments/Gears/{_prefabPath}";

        [Header("----- ��� -----")]
        [SerializeField] EquipSlot _equipSlot;

        [Header("----- �ִϸ��̼�(���� �ʿ��� ��쿡�� �� ����) -----")]
        [SerializeField] AnimatorLayerInfo _animatorLayerInfo;

        /// <summary>
        /// ��� ����.
        /// </summary>
        public virtual EquipType EquipType => EquipType.Gear;

        /// <summary>
        /// ��� ������ ����.
        /// </summary>
        public EquipSlot EquipSlot => _equipSlot;

        /// <summary>
        /// �ִϸ����� ���̾� ����.
        /// </summary>
        public AnimatorLayerInfo AnimatorLayerInfo => _animatorLayerInfo;



        public event Action OnValidated;

        /// <summary>
        /// �������� �����Ǿ��� �� ȣ��˴ϴ�.
        /// </summary>
        public void InvokeOnValidatedEvent()
        {
            OnValidated?.Invoke();
        }
    }
}


