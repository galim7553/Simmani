using GamePlay.Components;
using GamePlay.Hubs;
using GamePlay.Modules;
using GamePlay.Modules.AI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GamePlay.Scene
{
    public class TownScene : PlayScene
    {
        bool _hasPortaled = false;
        [Header("----- Æ÷Å» -----")]
        [SerializeField] TriggerHandler _mountainPortalTriggerHandler;

        [Header("----- ÀÓ½Ã -----")]
        [SerializeField] VillagerHub _seniorSimmani;
        [SerializeField] VillagerHub _pharmacist;
        [SerializeField] VillagerHub _soldier;
        [SerializeField] VillagerHub _daegam;
        [SerializeField] PassengerHub _testPassenger;
        [SerializeField] Transform _testPathsParent;

        protected override void Start()
        {
            base.Start();

            _heroHub.Components.NavMeshObstacle.enabled = true;

            _mountainPortalTriggerHandler.OnTriggerEntered += OnMountainPortalTriggerEntered;

            _heroHub.Modules.Get<IFatigueController>().SetActive(false);

            BuildVillager(GameManager.Inst.ModelManager.WorldModel.VillagerModelFactory.CreateModel("SeniorSimmani"), _seniorSimmani);
            BuildVillager(GameManager.Inst.ModelManager.WorldModel.VillagerModelFactory.CreateModel("Pharmacist"), _pharmacist);
            BuildVillager(GameManager.Inst.ModelManager.WorldModel.VillagerModelFactory.CreateModel("Soldier"), _soldier);
            BuildVillager(GameManager.Inst.ModelManager.WorldModel.VillagerModelFactory.CreateModel("Daegam"), _daegam);
            BuildPassenger(GameManager.Inst.ModelManager.WorldModel.PassengerModelFactory.CreateModel("TestPassenger"), _testPassenger);

            GameManager.Inst.ModelManager.WorldModel.StageModel.OnLevelChanged += OnStageLevelChanged;
        }

        void OnMountainPortalTriggerEntered(Collider collider)
        {
            if (_heroHub.Components.CharacterController == collider)
                PortalToMountain();

        }

        void PortalToMountain()
        {
            if (_hasPortaled == true) return;
            _hasPortaled = true;
            Clear();
            GameManager.Inst.SceneLoader.LoadScene(SceneLoader.SceneKey.Mountain);
        }

        void BuildVillager(VillagerModel model, VillagerHub villager)
        {
            villager.SetModel(model);

            villager.Modules.Set<IInteractor>(
                new Interactor(model.InteractorModel,
                villager.Components.Collider,
                this));

            villager.Modules.Initialize();
            villager.Initialize();
        }

        void BuildPassenger(PassengerModel model, PassengerHub passenger)
        {
            passenger.SetModel(model);

            Transform[] paths = _testPathsParent.Cast<Transform>().ToArray();

            Interactor interactor = new Interactor(model.InteractorModel, passenger.Components.Collider, this);
            NavMeshAgentFollwer follower = new NavMeshAgentFollwer(model.PassengerAIModel, passenger.Components.NavMeshAgent, passenger);
            PassengerAI passengerAI = new PassengerAI(model.PassengerAIModel, passenger.transform, passenger, follower, paths);

            passenger.Modules.Set<IInteractor>(interactor);
            passenger.Modules.Set<IFollower>(follower);
            passenger.Modules.Set<IPassengerAI>(passengerAI);

            IBehaviour behaviour = GameManager.Inst.ModelManager.WorldModel.BehaviourFactory.CreateBehaviour(model.PassengerAIModel.Config.BehaviourKey, passengerAI);
            passengerAI.Initialize(behaviour);

            passenger.AddUpdatable(follower);

            passenger.Modules.Initialize();
            passenger.Initialize();
        }

        

        void OnStageLevelChanged()
        {
            Clear();

            GameManager.Inst.SceneLoader.LoadScene(SceneLoader.SceneKey.Town);
        }

        public override void Clear()
        {
            base.Clear();

            GameManager.Inst.ModelManager.WorldModel.StageModel.OnLevelChanged -= OnStageLevelChanged;
        }
    }

}