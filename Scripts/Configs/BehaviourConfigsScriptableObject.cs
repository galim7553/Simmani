using GamePlay.Modules.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Configs
{
    [CreateAssetMenu(fileName = "BehaviourConfigs", menuName = "GameConfig/BehaviourConfigs")]
    public class BehaviourConfigsScriptableObject : ScriptableObject
    {
        [SerializeField] PatrolBehaviourConfig[] _patrolConfigs;
        [SerializeField] ReturnToSpawnBehaivourConfig[] _returnToSpawnConfigs;
        [SerializeField] TraceBehaviourConfig[] _traceConfigs;
        [SerializeField] AttackingBehaviourConfig[] _attackingConfigs;
        [SerializeField] PathFollowingBehaviourConfig[] _pathFollowingConfigs;

        public IReadOnlyList<PatrolBehaviourConfig> PatrolConfigs => _patrolConfigs;
        public IReadOnlyList<ReturnToSpawnBehaivourConfig> ReturnToSpawnConfigs => _returnToSpawnConfigs;
        public IReadOnlyList<TraceBehaviourConfig> TraceConfigs => _traceConfigs;
        public IReadOnlyList<AttackingBehaviourConfig> AttackingConfigs => _attackingConfigs;
        public IReadOnlyList<PathFollowingBehaviourConfig> PathFollowingConfigs => _pathFollowingConfigs;
    }
}


