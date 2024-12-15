using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    [Serializable]
    public class RotatorConfig : IRotatorModel
    {
        [SerializeField] float _baseRotSpeed;
        [SerializeField] RotatorLimiter _rotatorLimiter = new RotatorLimiter();
        float IRotatorModel.RotSpeed => _baseRotSpeed;
        RotatorLimiter IRotatorModel.RotatorLimiter => _rotatorLimiter;

        
    }
}


