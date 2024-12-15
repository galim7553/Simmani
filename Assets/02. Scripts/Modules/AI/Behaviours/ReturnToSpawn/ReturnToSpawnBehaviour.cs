using UnityEngine;

namespace GamePlay.Modules.AI
{
    public class ReturnToSpawnBehaviour : BehaviourBase<IReturnToSpawnBehaviourConfig, IFollowableAI>
    {
        Vector3 _spawnPosition;
        public ReturnToSpawnBehaviour(IReturnToSpawnBehaviourConfig config, IFollowableAI ai) : base(config, ai)
        {
            _spawnPosition = _ai.SpawnPosition;
        }

        public override void Enter()
        {
            _ai.Model.SetSpeedRaito(_config.SpeedRatio);
            _ai.FollowPosition(_spawnPosition);
        }

        public override void Exit()
        {
            _ai.Unfollow();
        }
    }
}


