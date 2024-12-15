using GamePlay.Datas;
using GamePlay.Hubs.Equipments;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Configs
{
    [Serializable]
    public abstract class EquipmentConfig : HubConfigBase, IValidatableConfig
    {
        public override string PrefabPath => $"Equipments/Gears/{_prefabPath}";

        [Header("----- ��� -----")]
        [SerializeField] EquipSlot _equipSlot;

        [Header("----- �ִϸ��̼�(���� �ʿ��� ��쿡�� �� ����) -----")]
        [SerializeField] AnimatorLayerInfo _animatorLayerInfo;

        public virtual EquipType EquipType => EquipType.Gear;
        public EquipSlot EquipSlot => _equipSlot;
        public AnimatorLayerInfo AnimatorLayerInfo => _animatorLayerInfo;



        public event Action OnValidated;
        public void InvokeOnValidatedEvent()
        {
            OnValidated?.Invoke();
        }
    }
}


