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

        [Header("----- 장비 -----")]
        [SerializeField] EquipSlot _equipSlot;

        [Header("----- 애니메이션(변경 필요한 경우에만 값 삽입) -----")]
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


