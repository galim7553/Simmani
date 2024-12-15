using System.Collections;
using System.Collections.Generic;
using GamePlay.Commands;
using GamePlay.Configs;
using GamePlay.Datas;
using GamePlay.Modules;
using GamePlay.Modules.AI;
using GamePlay.Presenters;

public class ConfigManager
{
    IResourceMap _resourceMap;

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


    List<ICommandConfig> _commandConfigs = new List<ICommandConfig>();
    List<IBehaviourConfig> _behaviourConfigs = new List<IBehaviourConfig>();
    List<EquipmentConfig> _equipmentConfigs = new List<EquipmentConfig>();
    List<DifficultyConfig> _difficultyConfigs = new List<DifficultyConfig>();

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


    public ConfigManager(IResourceMap resourceMap)
    {
        _resourceMap = resourceMap;

        Initialize();
    }
    void Initialize()
    {
        BindScriptableObjects();
        SetCommandConfigs();
        SetBehaviourConfigs();
        SetEquipmentConfigs();
        SetDifficultyConfigs();
    }
    void BindScriptableObjects()
    {
        _gamePlayConfigsScriptableObject = _resourceMap.LoadResource<GamePlayConfigsScriptableObject>("ScriptableObjects/GamePlayConfigs");
        _heroConfigScriptableObject = _resourceMap.LoadResource<HeroConfigScriptableObject>("ScriptableObjects/HeroConfig");
        _equipmentConfigScriptableObject = _resourceMap.LoadResource<EquipmentConfigsScriptableObject>("ScriptableObjects/EquipmentConfigs");
        _behaviourConfigScriptableObject = _resourceMap.LoadResource<BehaviourConfigsScriptableObject>("ScriptableObjects/BehaviourConfigs");
        _enemyConfigsScriptableObject = _resourceMap.LoadResource<EnemyConfigsScriptableObject>("ScriptableObjects/EnemyConfigs");
        _sceneConfigsScriptableObject = _resourceMap.LoadResource<SceneConfigsScriptableObject>("ScriptableObjects/SceneConfigs"); ;
        _interactableObjectConfigsScriptableObject = _resourceMap.LoadResource<InteractableObjectConfigsScriptableObject>("ScriptableObjects/InteractableObjectConfigs");
        _itemConfigsScriptableObject = _resourceMap.LoadResource<ItemConfigsScriptableObject>("ScriptableObjects/ItemConfigs");
        _commandConfigsScriptableObject = _resourceMap.LoadResource<CommandConfigsScriptableObject>("ScriptableObjects/CommandConfigs");
        _villagerConfigsScriptableObject = _resourceMap.LoadResource<VillagerConfigsScriptableObject>("ScriptableObjects/VillagerConfigs");
    }
    void SetCommandConfigs()
    {
        _commandConfigs.Add(_commandConfigsScriptableObject.DaegamCommandConfig);
        _commandConfigs.AddRange(_commandConfigsScriptableObject.HeroModelCommandConfigs);
        _commandConfigs.AddRange(_commandConfigsScriptableObject.SansamCommandConfigs);
        _commandConfigs.AddRange(_commandConfigsScriptableObject.ConversationCommandConfigs);
        _commandConfigs.AddRange(_commandConfigsScriptableObject.ShopCommandConfigs);
    }
    void SetBehaviourConfigs()
    {
        _behaviourConfigs.AddRange(_behaviourConfigScriptableObject.PatrolConfigs);
        _behaviourConfigs.AddRange(_behaviourConfigScriptableObject.ReturnToSpawnConfigs);
        _behaviourConfigs.AddRange(_behaviourConfigScriptableObject.TraceConfigs);
        _behaviourConfigs.AddRange(_behaviourConfigScriptableObject.AttackingConfigs);
        _behaviourConfigs.AddRange(_behaviourConfigScriptableObject.PathFollowingConfigs);
    }
    void SetEquipmentConfigs()
    {
        _equipmentConfigs.AddRange(_equipmentConfigScriptableObject.GearConfigs);
        _equipmentConfigs.AddRange(_equipmentConfigScriptableObject.WeaponConfigs);
    }
    void SetDifficultyConfigs()
    {
        _difficultyConfigs.Add(_gamePlayConfigsScriptableObject.EasyDifficulty);
        _difficultyConfigs.Add(_gamePlayConfigsScriptableObject.NormalDifficulty);
        _difficultyConfigs.Add(_gamePlayConfigsScriptableObject.DifficultDifficulty);
    }
}
