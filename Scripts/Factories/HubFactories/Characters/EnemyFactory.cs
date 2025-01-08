using UnityEngine;
using GamePlay.Hubs;
using GamePlay.Modules;
using GamePlay.Modules.AI;

namespace GamePlay.Factories
{
    /// <summary>
    /// 적(Enemy)을 생성하는 팩토리 인터페이스.
    /// </summary>
    public interface IEnemyFactory
    {
        EnemyHub Create(EnemyModel model, Vector3 spawnPosition);
    }

    /// <summary>
    /// 적(Enemy)을 생성하는 팩토리 클래스.
    /// </summary>
    public class EnemyFactory : FactoryBase<EnemyHub, EnemyModel>, IEnemyFactory
    {
        IDamageReceiverMappable _damageReceiverMappable;
        IBehaviourFactory _behaviourFactory;
        IResourceMap _resourceMap;

        /// <summary>
        /// EnemyFactory를 초기화합니다.
        /// </summary>
        /// <param name="poolManager">풀 매니저 객체.</param>
        /// <param name="resourceMap">리소스 매핑 객체.</param>
        /// <param name="damageReceiverMappable">데미지 수신자 매핑 객체.</param>
        /// <param name="behaviourFactory">행동 생성 팩토리 객체.</param>
        public EnemyFactory(PoolManager poolManager, IResourceMap resourceMap, IDamageReceiverMappable damageReceiverMappable, IBehaviourFactory behaviourFactory) : base(poolManager)
        {
            _resourceMap = resourceMap;
            _damageReceiverMappable = damageReceiverMappable;
            _behaviourFactory = behaviourFactory;
        }

        /// <summary>
        /// 적(Enemy)을 생성합니다.
        /// </summary>
        /// <param name="model">Enemy의 모델.</param>
        /// <param name="spawnPosition">적 생성 위치.</param>
        /// <returns>생성된 EnemyHub 객체.</returns>
        public EnemyHub Create(EnemyModel model, Vector3 spawnPosition)
        {
            EnemyHub enemyHub = _poolManager.GetFromPool(model.PrefabPath).GetOrAddComponent<EnemyHub>();

            enemyHub.SetModel(model);

            enemyHub.transform.localScale = Vector3.one * model.Config.Scale;
            foreach(var renderer in enemyHub.Components.Renderers)
                renderer.material = _resourceMap.LoadResource<Material>(model.Config.MaterialPath);

            enemyHub.Modules.Set<IDamageReceiver>(new DamageReceiver(model.DamageReceiverModel, enemyHub.transform, enemyHub.Components.TargetCollider, _damageReceiverMappable));
            enemyHub.Modules.Set<IDamageSender>(new DamageSender(model.DamageSenderModel, _damageReceiverMappable));

            NavMeshAgentFollwer follower = new NavMeshAgentFollwer(model.EnemyAIModel, enemyHub.Components.NavMeshAgent, enemyHub);
            enemyHub.Modules.Set<IFollower>(follower);

            CombatStater combatStater = new CombatStater(model.Config);
            enemyHub.Modules.Set<ICombatStater>(combatStater);

            TargetFinder targetFinder = new TargetFinder(model.TargetFinderModel, enemyHub.transform, enemyHub.Components.Collider, _damageReceiverMappable, enemyHub.Components.HitSphereCenter);
            enemyHub.Modules.Set<ITargetFinder>(targetFinder);

            EnemyAI enemyAI = new EnemyAI(model.EnemyAIModel, enemyHub.transform, enemyHub, follower, enemyHub, targetFinder, spawnPosition);
            enemyHub.Modules.Set<IEnemyAI>(enemyAI);

            IBehaviour[] behaviours = new IBehaviour[]
            {
                _behaviourFactory.CreateBehaviour(model.EnemyAIModel.Config.IdleBehaviourKey, enemyAI),
                _behaviourFactory.CreateBehaviour(model.EnemyAIModel.Config.TraceBehaviourKey, enemyAI),
                _behaviourFactory.CreateBehaviour(model.EnemyAIModel.Config.AttackingBehaviourKey, enemyAI),
            };
            enemyAI.Initialize(behaviours);

            enemyHub.AddUpdatable(follower);
            enemyHub.AddUpdatable(combatStater);

            enemyHub.Modules.Initialize();
            enemyHub.Initialize();

            return enemyHub;
        }
        public override EnemyHub Create(EnemyModel model)
        {
            Debug.LogWarning($"Enemy 생성에 필요한 매개변수가 부족합니다.");
            return Create(model, Vector3.zero);
        }
    }
}


