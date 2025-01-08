using System.Collections.Generic;
using GamePlay.Commands;
using GamePlay.Configs;
using GamePlay.Datas;
using GamePlay.Modules;
using GamePlay.Modules.AI;
using GamePlay.Presenters;

/// <summary>
/// 게임 설정을 관리하는 클래스.
/// ScriptableObject를 로드하여 게임 내 다양한 설정 데이터를 초기화하고 제공합니다.
/// </summary>
public class ConfigManager
{
    IResourceMap _resourceMap; // 리소스 로드 인터페이스

    // ScriptableObject 참조
    GamePlayConfigsScriptableObject _gamePlayConfigsScriptableObject;
    SceneConfigsScriptableObject _sceneConfigsScriptableObject;
    HeroConfigScriptableObject _heroConfigScriptableObject;
    EquipmentConfigsScriptableObject _equipmentConfigScriptableObject;
    BehaviourConfigsScriptableObject _behaviourConfigScriptableObject;
    EnemyConfigsScriptableObject _enemyConfigsScriptableObject;
    InteractableObjectConfigsScriptableObject _interactableObjectConfigsScriptableObject;
    ItemConfigsScriptableObject _itemConfigsScriptableObject;
    CommandConfigsScriptableObject _commandConfigsScriptableObject;
    VillagerConfigsScriptableObject _villagerConfigsScriptableObject;

    // 다양한 설정 데이터 리스트
    List<ICommandConfig> _commandConfigs = new List<ICommandConfig>();
    List<IBehaviourConfig> _behaviourConfigs = new List<IBehaviourConfig>();
    List<EquipmentConfig> _equipmentConfigs = new List<EquipmentConfig>();
    List<DifficultyConfig> _difficultyConfigs = new List<DifficultyConfig>();

    // 게임 설정 데이터 접근자
    public GamePlayConfig GamePlayConfig => _gamePlayConfigsScriptableObject.GamePlayConfig;
    public IInventoryConfig InventoryConfig => _gamePlayConfigsScriptableObject.GamePlayConfig;
    public IStageConfig StageConfig => _gamePlayConfigsScriptableObject.GamePlayConfig;
    public ITimeCycleConfig TimeCycleConfig => _gamePlayConfigsScriptableObject.GamePlayConfig;
    public IHotKeyGroupConfig HotKeyGroupConfig => _gamePlayConfigsScriptableObject.GamePlayConfig;
    public IDamagedEffectConfig DamagedEffectConfig => _gamePlayConfigsScriptableObject.GamePlayConfig;
    public IConversationConfig ConversationConfig => _gamePlayConfigsScriptableObject.GamePlayConfig;
    public MountainSceneConfig MountainSceneConfig => _sceneConfigsScriptableObject.MountainSceneConfig;
    public HeroConfig HeroConfig => _heroConfigScriptableObject.HeroConfig;
    public IReadOnlyList<EquipmentConfig> EquipmentConfigs => _equipmentConfigs;
    public IReadOnlyList<IBehaviourConfig> BehaviourConfigs => _behaviourConfigs;
    public IReadOnlyList<EnemyConfig> EnemyConfigs => _enemyConfigsScriptableObject.EnemyConfigs;
    public IReadOnlyList<InteractableObjectConfig> InteractableObjectConfigs => _interactableObjectConfigsScriptableObject.InteractableObjectConfigs;
    public IReadOnlyList<ItemConfig> ItemConfigs => _itemConfigsScriptableObject.ItemConfigs;
    public IReadOnlyList<ICommandConfig> CommandConfigs => _commandConfigs;
    public IReadOnlyList<VillagerConfig> VillagerConfigs => _villagerConfigsScriptableObject.VillagerConfigs;
    public IReadOnlyList<PassengerConfig> PassengerConfigs => _villagerConfigsScriptableObject.PassengerConfigs;
    public IReadOnlyList<DifficultyConfig> DifficultyConfigs => _difficultyConfigs;

    /// <summary>
    /// ConfigManager 생성자.
    /// 리소스 맵을 통해 설정 데이터를 로드하고 초기화합니다.
    /// </summary>
    /// <param name="resourceMap">리소스 로드 인터페이스</param>
    public ConfigManager(IResourceMap resourceMap)
    {
        _resourceMap = resourceMap;
        Initialize();
    }

    /// <summary>
    /// 설정 데이터를 초기화합니다.
    /// </summary>
    void Initialize()
    {
        BindScriptableObjects(); // ScriptableObject 로드
        SetCommandConfigs(); // 커맨드 설정 초기화
        SetBehaviourConfigs(); // 행동 설정 초기화
        SetEquipmentConfigs(); // 장비 설정 초기화
        SetDifficultyConfigs(); // 난이도 설정 초기화
    }

    /// <summary>
    /// ScriptableObject를 로드하여 참조를 바인딩합니다.
    /// </summary>
    void BindScriptableObjects()
    {
        _gamePlayConfigsScriptableObject = _resourceMap.LoadResource<GamePlayConfigsScriptableObject>("ScriptableObjects/GamePlayConfigs");
        _heroConfigScriptableObject = _resourceMap.LoadResource<HeroConfigScriptableObject>("ScriptableObjects/HeroConfig");
        _equipmentConfigScriptableObject = _resourceMap.LoadResource<EquipmentConfigsScriptableObject>("ScriptableObjects/EquipmentConfigs");
        _behaviourConfigScriptableObject = _resourceMap.LoadResource<BehaviourConfigsScriptableObject>("ScriptableObjects/BehaviourConfigs");
        _enemyConfigsScriptableObject = _resourceMap.LoadResource<EnemyConfigsScriptableObject>("ScriptableObjects/EnemyConfigs");
        _sceneConfigsScriptableObject = _resourceMap.LoadResource<SceneConfigsScriptableObject>("ScriptableObjects/SceneConfigs");
        _interactableObjectConfigsScriptableObject = _resourceMap.LoadResource<InteractableObjectConfigsScriptableObject>("ScriptableObjects/InteractableObjectConfigs");
        _itemConfigsScriptableObject = _resourceMap.LoadResource<ItemConfigsScriptableObject>("ScriptableObjects/ItemConfigs");
        _commandConfigsScriptableObject = _resourceMap.LoadResource<CommandConfigsScriptableObject>("ScriptableObjects/CommandConfigs");
        _villagerConfigsScriptableObject = _resourceMap.LoadResource<VillagerConfigsScriptableObject>("ScriptableObjects/VillagerConfigs");
    }

    /// <summary>
    /// 커맨드 설정 데이터를 초기화합니다.
    /// </summary>
    void SetCommandConfigs()
    {
        _commandConfigs.Add(_commandConfigsScriptableObject.DaegamCommandConfig);
        _commandConfigs.AddRange(_commandConfigsScriptableObject.HeroModelCommandConfigs);
        _commandConfigs.AddRange(_commandConfigsScriptableObject.SansamCommandConfigs);
        _commandConfigs.AddRange(_commandConfigsScriptableObject.ConversationCommandConfigs);
        _commandConfigs.AddRange(_commandConfigsScriptableObject.ShopCommandConfigs);
    }

    /// <summary>
    /// 행동 설정 데이터를 초기화합니다.
    /// </summary>
    void SetBehaviourConfigs()
    {
        _behaviourConfigs.AddRange(_behaviourConfigScriptableObject.PatrolConfigs);
        _behaviourConfigs.AddRange(_behaviourConfigScriptableObject.ReturnToSpawnConfigs);
        _behaviourConfigs.AddRange(_behaviourConfigScriptableObject.TraceConfigs);
        _behaviourConfigs.AddRange(_behaviourConfigScriptableObject.AttackingConfigs);
        _behaviourConfigs.AddRange(_behaviourConfigScriptableObject.PathFollowingConfigs);
    }

    /// <summary>
    /// 장비 설정 데이터를 초기화합니다.
    /// </summary>
    void SetEquipmentConfigs()
    {
        _equipmentConfigs.AddRange(_equipmentConfigScriptableObject.GearConfigs);
        _equipmentConfigs.AddRange(_equipmentConfigScriptableObject.WeaponConfigs);
    }

    /// <summary>
    /// 난이도 설정 데이터를 초기화합니다.
    /// </summary>
    void SetDifficultyConfigs()
    {
        _difficultyConfigs.Add(_gamePlayConfigsScriptableObject.EasyDifficulty);
        _difficultyConfigs.Add(_gamePlayConfigsScriptableObject.NormalDifficulty);
        _difficultyConfigs.Add(_gamePlayConfigsScriptableObject.DifficultDifficulty);
    }
}