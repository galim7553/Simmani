using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.Modules;

namespace GamePlay.Datas
{
    [Serializable]
    public class TrialData
    {
        [SerializeField] InventoryData _inventoryData = new InventoryData();
        [SerializeField] StageData _stageData = new StageData();
        [SerializeField] TimeCycleData _timeCycleData = new TimeCycleData();
        [SerializeField] HeroData _heroData = new HeroData();

        public InventoryData InventoryData => _inventoryData;
        public StageData StageData => _stageData;
        public TimeCycleData TimeCycleData => _timeCycleData;
        public HeroData HeroData => _heroData;
    }
}


