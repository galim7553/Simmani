using System.Collections.Generic;
using GamePlay.Components;
using GamePlay.Hubs;
using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Scene
{
    public class MountainScene : PlayScene
    {
        MountainSceneModel _model;

        [Header("----- 포탈 -----")]
        bool _hasPortaled = false;
        [SerializeField] TriggerHandler _townPortalTriggerHandler;

        [Header("----- Enemy -----")]
        [SerializeField] Transform _enemySpawnPoint;


        [Header("----- Terrain -----")]
        [SerializeField] Transform _terrainParent;
        [SerializeField] Transform[] _objSpawnPoints;
        public Transform TerrainParent => _terrainParent;
        public IReadOnlyList<Transform> ObjSpawnPoints => _objSpawnPoints;

        // ----- Modules ----- //
        MountainController _mountainController;
        TerrainCuller _terrainCuller;
        // ----- Modules ----- //

        public HeroHub HeroHub => _heroHub;

        protected override void Awake()
        {
            base.Awake();

            _model = GameManager.Inst.ModelManager.WorldModel.MountainSceneModel;

            _terrainCuller = new TerrainCuller(_model.Config, _terrainParent, this);
            _mountainController = new MountainController(_model.MountainData, this, GameManager.Inst.ModelManager.WorldModel, GameManager.Inst.PoolManager, GameManager.Inst.ResourceManager);
        }


        protected override void Start()
        {
            base.Start();

            _heroHub.Components.NavMeshObstacle.enabled = false;

            _mountainController.Initialize();
            StartCoroutine(_mountainController.SpawnOniCo());
            _terrainCuller.Start();

            _heroHub.Modules.Get<IFatigueController>().SetActive(true);

            _townPortalTriggerHandler.OnTriggerEntered += OnTownPortalTriggerEntered;
        }

        void OnTownPortalTriggerEntered(Collider collider)
        {
            if (_heroHub.Components.CharacterController == collider)
                PortalToTown();

        }
        void PortalToTown()
        {
            Debug.Log("마을로 이동");
            
            if (_hasPortaled == true) return;
            _hasPortaled = true;
            Clear();
            GameManager.Inst.SceneLoader.LoadScene(SceneLoader.SceneKey.Town);
        }


        protected override void Update()
        {
            base.Update();

            if (Input.GetKeyDown(KeyCode.P))
                _mountainController.SpawnOni();
        }

        public override void Clear()
        {
            base.Clear();

            _mountainController.Clear();
        }
    }
}


