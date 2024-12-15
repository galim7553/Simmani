using GamePlay.Modules;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Datas
{
    [Serializable]
    public class HeroData
    {
        [SerializeField] FatigueData _fatigueData = new FatigueData();

        public FatigueData FatigueData => _fatigueData;
    }
}


