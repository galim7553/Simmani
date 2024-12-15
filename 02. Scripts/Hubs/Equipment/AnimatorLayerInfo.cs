using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Hubs.Equipments
{
    [Serializable]
    public class AnimatorLayerInfo
    {
        [SerializeField] int _targetLayerIndex;
        [SerializeField] float _weight;

        public int TargetLayerIndex => _targetLayerIndex;
        public float Weight => _weight;
    }
}