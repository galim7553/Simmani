using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GamePlay.Datas;
using GamePlay.Factories;
using GamePlay.Hubs;
using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Scene
{
    public class MountainController : ModuleBase, IEnemyMap
    {
        MountainData _mountainData;

        MountainScene _mountainScene;
        WorldModel _worldModel;
        PoolManager _poolManager;
        IResourceMap _resourceMap;

        IStageModel _stageModel;

        Terrain[] _terrains;
        Transform _enemyParent;

        IEnemyFactory _enemyFactory;
        InteractableObjectFactory _interactableObjectFactory;


        Dictionary<int, EnemyHub> _oniMap = new Dictionary<int, EnemyHub>();
        List<EnemyHub> _tigers = new List<EnemyHub>();
        List<InteractableObject> _sansams = new List<InteractableObject>();

        public MountainController(MountainData mountainData, MountainScene mountainScene,
            WorldModel worldModel, PoolManager poolManager, IResourceMap resourceMap)
        {
            _mountainData = mountainData;
            _mountainScene = mountainScene;
            _worldModel = worldModel;
            _poolManager = poolManager;
            _resourceMap = resourceMap;
        }

        public void Initialize()
        {
            _stageModel = _worldModel.StageModel;

            _terrains = _mountainScene.TerrainParent.GetComponentsInChildren<Terrain>(true);
            _enemyParent = _mountainScene.transform;

            _enemyFactory = new EnemyFactory(_poolManager, _resourceMap, _mountainScene, _worldModel.BehaviourFactory);
            _interactableObjectFactory = new InteractableObjectFactory(_poolManager, _mountainScene);

            SpawnSansams();
            SpawnTigers();
        }

        void SpawnTigers()
        {
            foreach(var point in _mountainScene.ObjSpawnPoints)
                SpawnTiger(point);
        }

        void SpawnTiger(Transform spawnPoint)
        {
            CellData cellData = _mountainData.GetCellData(spawnPoint.position);
            if (cellData == null) return;

            Vector3 position = spawnPoint.position;
            position.y = _terrains[cellData.TerrainIndex].SampleHeight(position);

            EnemyModel enemyModel = _worldModel.EnemyModelFactory.CreateModel("Tiger");
            EnemyHub enemy = _enemyFactory.Create(enemyModel, position);

            enemy.Components.NavMeshAgent.Warp(position);

            enemy.transform.SetParent(_enemyParent, true);

            _tigers.Add(enemy);
        }

        public IEnumerator SpawnOniCo()
        {
            while (true)
            {
                WaitForSeconds waitForSeconds = new WaitForSeconds(_stageModel.GetEnemySpawnSpan());
                yield return waitForSeconds;
                SpawnOni();
            }
        }
        public void SpawnOni()
        {
            if (_oniMap.Count >= _worldModel.DifficultyModel.Config.MaxOniCount) return;

            Vector3 heroPosition = _mountainScene.HeroHub.transform.position;
            CellData cellData = _mountainData.GetSurroundingCellDatas(heroPosition, _stageModel.Config.MinEnemySpawnRadius, _stageModel.Config.MaxEnemySpawnRadius).Choose();
            if (cellData == null) return;

            Vector3 position = cellData.CenterPos + Random.insideUnitSphere * _mountainData.SpawnRadius;
            position.y = _terrains[cellData.TerrainIndex].SampleHeight(position);

            EnemyModel enemyModel = _worldModel.EnemyModelFactory.CreateModel(_stageModel.GetEnemyKey());
            EnemyHub enemy = _enemyFactory.Create(enemyModel, position);

            enemy.Components.NavMeshAgent.Warp(position);

            enemy.transform.SetParent(_enemyParent, true);

            _oniMap[enemyModel.Id] = enemy;
            enemy.SetEnemyMap(this);
        }
        public void RemoveEnemy(int id)
        {
            _oniMap.Remove(id);
        }



        void SpawnSansams()
        {
            List<CellData> cellDatas = _mountainData.SpawnableCellDatas.ToList();
            if (cellDatas == null || cellDatas.Count == 0) return;

            cellDatas.Shuffle();

            for(int i = 0; i < 300; i++)
                SpawnSansam(cellDatas[i]);
        }

        void SpawnSansam(CellData cellData)
        {
            Terrain terrain = _terrains[cellData.TerrainIndex];
            Vector3 position = cellData.CenterPos + Random.insideUnitSphere * _mountainData.SpawnRadius;
            position.y = terrain.SampleHeight(position);

            Vector3 upDirection = terrain.GetNormalAtWorldPosition(position);

            InteractableObjectModel model = _worldModel.InteractableObjectModelFactory.CreateModel("SanSam");
            InteractableObject sansam = _interactableObjectFactory.Create(model);

            sansam.transform.position = position;
            sansam.transform.up = upDirection;

            sansam.transform.SetParent(terrain.transform, true);

            _sansams.Add(sansam);
        }

        public override void Clear()
        {
            base.Clear();

            List<EnemyHub> onies = _oniMap.Values.ToList();
            foreach (var oni in onies)
                oni.DestroyOrReturnToPool();

            foreach (var tiger in _tigers)
            {
                if (tiger.Modules.HasInitialized == true)
                    tiger.DestroyOrReturnToPool();
            }

            foreach(var sansam in _sansams)
            {
                if(sansam.Modules.HasInitialized == true)
                    sansam.DestroyOrReturnToPool();
            }
        }
    }
}


