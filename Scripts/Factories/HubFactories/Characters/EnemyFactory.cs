using UnityEngine;
using GamePlay.Hubs;
using GamePlay.Modules;
using GamePlay.Modules.AI;

namespace GamePlay.Factories
{
    /// <summary>
    /// ��(Enemy)�� �����ϴ� ���丮 �������̽�.
    /// </summary>
    public interface IEnemyFactory
    {
        EnemyHub Create(EnemyModel model, Vector3 spawnPosition);
    }

    /// <summary>
    /// ��(Enemy)�� �����ϴ� ���丮 Ŭ����.
    /// </summary>
    public class EnemyFactory : FactoryBase<EnemyHub, EnemyModel>, IEnemyFactory
    {
        IDamageReceiverMappable _damageReceiverMappable;
        IBehaviourFactory _behaviourFactory;
        IResourceMap _resourceMap;

        /// <summary>
        /// EnemyFactory�� �ʱ�ȭ�մϴ�.
        /// </summary>
        /// <param name="poolManager">Ǯ �Ŵ��� ��ü.</param>
        /// <param name="resourceMap">���ҽ� ���� ��ü.</param>
        /// <param name="damageReceiverMappable">������ ������ ���� ��ü.</param>
        /// <param name="behaviourFactory">�ൿ ���� ���丮 ��ü.</param>
        public EnemyFactory(PoolManager poolManager, IResourceMap resourceMap, IDamageReceiverMappable damageReceiverMappable, IBehaviourFactory behaviourFactory) : base(poolManager)
        {
            _resourceMap = resourceMap;
            _damageReceiverMappable = damageReceiverMappable;
            _behaviourFactory = behaviourFactory;
        }

        /// <summary>
        /// ��(Enemy)�� �����մϴ�.
        /// </summary>
        /// <param name="model">Enemy�� ��.</param>
        /// <param name="spawnPosition">�� ���� ��ġ.</param>
        /// <returns>������ EnemyHub ��ü.</returns>
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
            Debug.LogWarning($"Enemy ������ �ʿ��� �Ű������� �����մϴ�.");
            return Create(model, Vector3.zero);
        }
    }
}


