using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    [Serializable]
    public class FatigueData
    {
        [SerializeField] float _fatigue;
        public float Fatigue => _fatigue;

        public void SetFatigue(float fatigue)
        {
            _fatigue = fatigue;
        }
    }
}


