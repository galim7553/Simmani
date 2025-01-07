using GamePlay.Hubs.Equipments;
using System;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// 장비 설정값을 정의하는 추상 클래스.
    /// </summary>
    [Serializable]
    public abstract class EquipmentConfig : HubConfigBase, IValidatableConfig
    {
        public override string PrefabPath => $"Equipments/Gears/{_prefabPath}";

        [Header("----- 장비 -----")]
        [SerializeField] EquipSlot _equipSlot;

        [Header("----- 애니메이션(변경 필요한 경우에만 값 삽입) -----")]
        [SerializeField] AnimatorLayerInfo _animatorLayerInfo;

        /// <summary>
        /// 장비 유형.
        /// </summary>
        public virtual EquipType EquipType => EquipType.Gear;

        /// <summary>
        /// 장비가 장착될 슬롯.
        /// </summary>
        public EquipSlot EquipSlot => _equipSlot;

        /// <summary>
        /// 애니메이터 레이어 정보.
        /// </summary>
        public AnimatorLayerInfo AnimatorLayerInfo => _animatorLayerInfo;



        public event Action OnValidated;

        /// <summary>
        /// 설정값이 검증되었을 때 호출됩니다.
        /// </summary>
        public void InvokeOnValidatedEvent()
        {
            OnValidated?.Invoke();
        }
    }
}


