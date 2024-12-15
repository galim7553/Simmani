using System.Collections;
using System.Collections.Generic;
using GamePlay.Hubs.Equipments;
using UnityEngine;

namespace GamePlay.Modules
{
    public static class EquipperUtil
    {
        static Dictionary<EquipSlot, HumanBodyBones> _slotBodyBoneMap = new Dictionary<EquipSlot, HumanBodyBones>()
        {
            {EquipSlot.LeftHand, HumanBodyBones.LeftHand },
            {EquipSlot.RightHand, HumanBodyBones.RightHand }
        };

        public static bool TryGetHumanBodyBone(EquipSlot equipSlot, out HumanBodyBones bone)
        {
            return _slotBodyBoneMap.TryGetValue(equipSlot, out bone);
        }
    }
}

