using System.Collections;
using System.Collections.Generic;
using GamePlay.Modules.AI;
using UnityEngine;

namespace GamePlay.Factories
{
    public class BehaviourFactory : ConfigMapBase<IBehaviourConfig>, IBehaviourFactory
    {
        public BehaviourFactory(IEnumerable<IBehaviourConfig> configs) : base(configs)
        { 
        }
        
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

            Debug.LogError($"{key} Behaviour가 없거나, {ai.Key} AI와 대응하는 Behaviour가 존재하지 않습니다.");
            return null;
        }
    }
}


