using System.Collections.Generic;
using GamePlay.Modules.AI;
using UnityEngine;

namespace GamePlay.Factories
{
    /// <summary>
    /// 다양한 AI 행동(Behaviour)을 생성하는 팩토리 클래스.
    /// 행동 설정과 AI 유형에 따라 적합한 행동 객체를 반환합니다.
    /// </summary>
    public class BehaviourFactory : ConfigMapBase<IBehaviourConfig>, IBehaviourFactory
    {
        /// <summary>
        /// 행동 설정을 기반으로 팩토리를 초기화합니다.
        /// </summary>
        /// <param name="configs">행동 설정의 컬렉션.</param>
        public BehaviourFactory(IEnumerable<IBehaviourConfig> configs) : base(configs)
        { 
        }

        /// <summary>
        /// 주어진 키와 AI 인스턴스를 기반으로 행동(Behaviour)을 생성합니다.
        /// </summary>
        /// <param name="key">행동의 키 값.</param>
        /// <param name="ai">행동을 수행할 AI 인스턴스.</param>
        /// <returns>생성된 행동 인스턴스.</returns>
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


