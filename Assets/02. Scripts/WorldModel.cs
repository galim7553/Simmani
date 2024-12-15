using GamePlay.Datas;
using GamePlay.Factories;
using GamePlay.Hubs;
using GamePlay.Modules;
using GamePlay.Scene;

namespace GamePlay
{
    public class WorldModel
    {
        ConfigManager _configManager;
        TrialData _trialData;
        IConversationMap _conversationMap;

        // ----- UniqueModel ----- //
        public HeroModel HeroModel { get; private set; }
        public MountainSceneModel MountainSceneModel { get; private set; }
        public StageModel StageModel { get; private set; }
        public TimeCycleModel TimeCycleModel { get; private set; }
        public InventoryModel InventoryModel { get; private set; }
        public IInteractorDectectorModel InteractorDectectorModel => _configManager.GamePlayConfig;
        public DifficultyModel DifficultyModel { get; private set; }
        // ----- UniqueModel ----- //

        // ----- CommandFactory ----- //
        public CommandFactory CommandFactory { get; private set; }
        // ----- CommandFactory ----- //

        // ----- BehaviourFactory ----- //
        public BehaviourFactory BehaviourFactory { get; private set; }
        // ----- BehaviourFactory ----- //

        // ----- ConversationModelMap ----- //
        public ConversationModelMap ConversationModelMap { get; private set; }
        // ----- ConversationModelMap ----- //


        // ----- ModelFactory ----- //
        public EquipmentModelFactory EquipmentModelFactory { get; private set; }
        public EnemyModelFactory EnemyModelFactory { get; private set; }
        public InteractableObjectModelFactory InteractableObjectModelFactory { get; private set; }
        public VillagerModelFactory VillagerModelFactory { get; private set; }
        public PassengerModelFactory PassengerModelFactory {  get; private set; }
        public ItemModelFactory ItemModelFactory { get; private set; }
        // ----- ModelFactory ----- //

        public bool HasOpeningPlayed { get; private set; } = false;

        public WorldModel(ConfigManager configManager, TrialData trialData, IConversationMap conversationMap)
        {
            _configManager = configManager;
            _trialData = trialData;
            _conversationMap = conversationMap;

            Initialize();
        }

        void Initialize()
        {
            CreateUniqueModels();
            CreateCommandFactory();
            CreateBehaviourFactory();
            CreateConversationModelMap();
            CreateModelFactories();
            CreateInventoryModel();
        }

        void CreateUniqueModels()
        {
            HeroModel = new HeroModel(_configManager.HeroConfig, _trialData.HeroData);
            MountainSceneModel = new MountainSceneModel(_configManager.MountainSceneConfig);
            StageModel = new StageModel(_configManager.StageConfig, _trialData.StageData);
            TimeCycleModel = new TimeCycleModel(_configManager.TimeCycleConfig, _trialData.TimeCycleData);
            DifficultyModel = new DifficultyModel(_configManager.DifficultyConfigs[(int)_configManager.GamePlayConfig.BasicDifficultyType]);
        }

        void CreateCommandFactory()
        {
            CommandFactory = new CommandFactory(_configManager.CommandConfigs, this);
        }
        void CreateConversationModelMap()
        {
            ConversationModelMap = new ConversationModelMap(_configManager.ConversationConfig, _conversationMap);
        }
        void CreateBehaviourFactory()
        {
            BehaviourFactory = new BehaviourFactory(_configManager.BehaviourConfigs);
        }
        void CreateModelFactories()
        {
            EquipmentModelFactory = new EquipmentModelFactory(_configManager.EquipmentConfigs);
            EnemyModelFactory = new EnemyModelFactory(_configManager.EnemyConfigs);
            InteractableObjectModelFactory = new InteractableObjectModelFactory(_configManager.InteractableObjectConfigs, CommandFactory);
            VillagerModelFactory = new VillagerModelFactory(_configManager.VillagerConfigs, CommandFactory);
            PassengerModelFactory = new PassengerModelFactory(_configManager.PassengerConfigs, CommandFactory);
            ItemModelFactory = new ItemModelFactory(_configManager.ItemConfigs, EquipmentModelFactory, CommandFactory);
        }
        void CreateInventoryModel()
        {
            InventoryModel = new InventoryModel(_configManager.InventoryConfig, _trialData.InventoryData,
                HeroModel, ItemModelFactory);

            // Test
            InventoryModel.AddItem("Torch");
            InventoryModel.AddItem("HwanDo");
        }

        public void SetHasOpeningPlayed(bool hasOpeningPlayed)
        {
            HasOpeningPlayed = hasOpeningPlayed;
        }
    }
}


