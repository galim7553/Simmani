using System;
using UnityEngine;
using GamePlay.Modules;

namespace GamePlay.Datas
{
    /// <summary>
    /// 게임의 시도 데이터를 저장하는 클래스입니다.
    /// 각 주요 데이터(인벤토리, 스테이지, 시간, 플레이어 캐릭터)로 구성됩니다.
    /// </summary>
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


