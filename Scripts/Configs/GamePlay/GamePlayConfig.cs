using System;
using System.Collections.Generic;
using GamePlay.Datas;
using GamePlay.Modules;
using GamePlay.Presenters;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// ���� �÷����� �������� ������ �����ϴ� Ŭ�����Դϴ�.
    /// �κ��丮, ��������, �ð� �帧, ��ȣ�ۿ�, ��ȭ ��� �� �پ��� ������ �����մϴ�.
    /// </summary>
    [Serializable]
    public class GamePlayConfig : IInventoryConfig, IStageConfig, ITimeCycleConfig,
        IHotKeyGroupConfig, IDamagedEffectConfig, IInteractorDetectorConfig, IInteractorDectectorModel,
        IConversationConfig, IRotatorConfig, IRotatorModel
    {
        [Header("----- ī�޶� -----")]
        [SerializeField] float _baseRotSpeed = 50.0f;
        [SerializeField] RotatorLimiter _rotatorLimiter = new RotatorLimiter();

        float IRotatorConfig.BaseRotSpeed => _baseRotSpeed;
        RotatorLimiter IRotatorConfig.RotatorLimiter => _rotatorLimiter;
        float IRotatorModel.RotSpeed => _baseRotSpeed;
        RotatorLimiter IRotatorModel.RotatorLimiter => _rotatorLimiter;


        [Header("----- �κ��丮 -----")]
        [SerializeField] int _slotLimit = 20;
        [SerializeField] string _itemOnInventoryPrefabPath = "ItemOnInventory";
        [SerializeField] string _sellGuideTextKey = "Sell_Text";
        [SerializeField] string _buyGuideTextKey = "Purchase_Text";
        [SerializeField] string _notEnoughSlotTextKey = "Need_Slot_Text";
        [SerializeField] string _notEnoughGoldTextKey = "Need_Gold_Text";
        [SerializeField] string _useButtonTextKey = "Using_Btn";
        [SerializeField] string _unuseButtonTextKey = "UnEquip_Text";
        [SerializeField] string _dumpButtonTextKey = "Delete_Btn";
        int IInventoryConfig.SlotLimit => _slotLimit;
        string IInventoryConfig.ItemOnInventoryViewPrefabPath => $"Views/{_itemOnInventoryPrefabPath}";

        string IInventoryConfig.SellGuideTextKey => _sellGuideTextKey;
        string IInventoryConfig.BuyGuideTextKey => _buyGuideTextKey;
        string IInventoryConfig.NotEnoughGoldTextKey => _notEnoughGoldTextKey;
        string IInventoryConfig.NotEnoughtSlotTextKey => _notEnoughSlotTextKey;
        string IInventoryConfig.UseButtonTextKey => _useButtonTextKey;
        string IInventoryConfig.UnuseButtonTextKey => _unuseButtonTextKey;
        string IInventoryConfig.DumpButtonTextKey => _dumpButtonTextKey;

        [Header("----- �������� -----")]
        [SerializeField] int _minInitialSansamCount = 5;
        [SerializeField] int _maxInitialSansamCount = 15;
        [SerializeField] int _minIncreaseSansamCount = 3;
        [SerializeField] int _maxIncreaseSansamCount = 10;
        [SerializeField] StageEnemyInfo[] _stageEnemyInfos = new StageEnemyInfo[] {new StageEnemyInfo()};
        [SerializeField] float _minEnemySpawnRadius = 30.0f;
        [SerializeField] float _maxEnemySpawnRadius = 60.0f;

        int IStageConfig.MinInitialSansamCount => _minInitialSansamCount;
        int IStageConfig.MaxInitialSansamCount => _maxInitialSansamCount;
        int IStageConfig.MinIncreaseSansamCount => _minIncreaseSansamCount;
        int IStageConfig.MaxIncreaseSansamCount => _maxIncreaseSansamCount;
        float IStageConfig.MinEnemySpawnRadius => _minEnemySpawnRadius;
        float IStageConfig.MaxEnemySpawnRadius => _maxEnemySpawnRadius;
        IReadOnlyList<StageEnemyInfo> IStageConfig.StageEnemyInfos => _stageEnemyInfos;


        [Header("----- �ð� �帧 -----")]
        [SerializeField] float _timeRatio = 12.0f;
        [SerializeField] SunInfo _noonSunInfo;
        [SerializeField] SunInfo _eveningSunInfo;
        [SerializeField] SunInfo _midnightSunInfo;
        float ITimeCycleConfig.TimeRatio => _timeRatio;
        SunInfo ITimeCycleConfig.NoonSunInfo => _noonSunInfo;        
        SunInfo ITimeCycleConfig.EveningSunInfo => _eveningSunInfo;
        SunInfo ITimeCycleConfig.MidnightSunInfo => _midnightSunInfo;
        string ITimeCycleConfig.GameDayTextKeyFormat => "Day_{0}";
        string ITimeCycleConfig.KoreanHourTextKeyFormat => "Time_{0}";
        string ITimeCycleConfig.KoreanHourSpritePathFormat => "Sprites/KoreanHours/korean_hour_{0}";

        [Header("----- ������ ��Ű -----")]
        [SerializeField] HotKeyInfo[] _hotKeyInfos;
        IReadOnlyList<HotKeyInfo> IHotKeyGroupConfig.HotKeyInfos => _hotKeyInfos;

        [Header("----- �ǰ� �� UI ����Ʈ -----")]
        [SerializeField] float _warningDuration = 2.0f;
        [SerializeField] float _warningFadeOutDuration = 3.0f;
        [SerializeField] float _bloodDuration = 4.0f;
        [SerializeField] float _bloodFadeOutDuration = 5.0f;
        float IDamagedEffectConfig.WarningDuration => _warningDuration;
        float IDamagedEffectConfig.WarningFadeOutDuration => _warningFadeOutDuration;
        float IDamagedEffectConfig.BloodDuration => _bloodDuration;
        float IDamagedEffectConfig.BloodFadeOutDuration => _bloodFadeOutDuration;


        [Header("----- ��ȣ�ۿ� ���� -----")]
        [SerializeField] float _rayDistance = 1.0f;
        [SerializeField] LayerMask _interactableLayerMask = 1 << 11;

        float IInteractorDetectorConfig.RayDistance => _rayDistance;
        LayerMask IInteractorDetectorConfig.InteractableLayerMask => _interactableLayerMask;
        IInteractorDetectorConfig IInteractorDectectorModel.Config => this;

        [Header("----- ��ȭ ��� -----")]
        [SerializeField] float _letterSpan = 0.1f;
        float IConversationConfig.LetterSpan => _letterSpan;

        [Header("----- �⺻ ���̵� -----")]
        [SerializeField] IDifficultyConfig.DifficultyType _basicDifficultyType = IDifficultyConfig.DifficultyType.Easy;
        public IDifficultyConfig.DifficultyType BasicDifficultyType => _basicDifficultyType;
    }
}


