using System.Collections.Generic;
using GamePlay.Modules.AI;
using UnityEngine;

namespace GamePlay.Factories
{
    /// <summary>
    /// �پ��� AI �ൿ(Behaviour)�� �����ϴ� ���丮 Ŭ����.
    /// �ൿ ������ AI ������ ���� ������ �ൿ ��ü�� ��ȯ�մϴ�.
    /// </summary>
    public class BehaviourFactory : ConfigMapBase<IBehaviourConfig>, IBehaviourFactory
    {
        /// <summary>
        /// �ൿ ������ ������� ���丮�� �ʱ�ȭ�մϴ�.
        /// </summary>
        /// <param name="configs">�ൿ ������ �÷���.</param>
        public BehaviourFactory(IEnumerable<IBehaviourConfig> configs) : base(configs)
        { 
        }

        /// <summary>
        /// �־��� Ű�� AI �ν��Ͻ��� ������� �ൿ(Behaviour)�� �����մϴ�.
        /// </summary>
        /// <param name="key">�ൿ�� Ű ��.</param>
        /// <param name="ai">�ൿ�� ������ AI �ν��Ͻ�.</param>
        /// <returns>������ �ൿ �ν��Ͻ�.</returns>
        public IBehaviour CreateBehaviour(string key, IAI ai)
        {
            if(_configMap.TryGetValue(key, out var config))
            {
                switch (config)
                {
                    case IPatrolBehaviourConfig patrolBehaviourConfig when ai is IFollowableAI followable:
                        return new PatrolBehaviour(patrolBehaviourConfig, followable);
                    case ITraceBehaviourConfig traceBehaviourConfig when ai is ITargetFollowableAI followable:
                        return new TraceBehaviour(traceBehaviourConfig, followable);
                    case IAttackingBehaviourConfig attackingBehaviourConfig when ai is IAttackableAI attackable:
                        return new AttackingBehaviour(attackingBehaviourConfig, attackable);
                    case IReturnToSpawnBehaviourConfig returnToSpawnBehaviourConfig when ai is IFollowableAI followable:
                        return new ReturnToSpawnBehaviour(returnToSpawnBehaviourConfig, followable);
                    case IPathFollowingBehaviourConfig pathFollowingBehaviourConfig when ai is IPathFollowableAI followable:
                        return new PathFollowingBehaviour(pathFollowingBehaviourConfig, followable);
                }
            }

            Debug.LogError($"{key} Behaviour�� ���ų�, {ai.Key} AI�� �����ϴ� Behaviour�� �������� �ʽ��ϴ�.");
            return null;
        }
    }
}


