using System.Collections.Generic;
using GamePlay.Hubs.Equipments;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 장비 슬롯과 본(HumanBodyBones) 간의 매핑 유틸리티 클래스.
    /// </summary>
    public static class EquipperUtil
    {
        static Dictionary<EquipSlot, HumanBodyBones> _slotBodyBoneMap = new Dictionary<EquipSlot, HumanBodyBones>()
        {
            { EquipSlot.LeftHand, HumanBodyBones.LeftHand },
            { EquipSlot.RightHand, HumanBodyBones.RightHand }
        };

        /// <summary>
        /// 장비 슬롯과 연결된 본(HumanBodyBones)을 반환합니다.
        /// </summary>
        public static bool TryGetHumanBodyBone(EquipSlot equipSlot, out HumanBodyBones bone)
        {
            return _slotBodyBoneMap.TryGetValue(equipSlot, out bone);
        }
    }
}
