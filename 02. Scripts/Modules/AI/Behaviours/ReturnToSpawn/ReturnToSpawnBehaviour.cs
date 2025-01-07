using UnityEngine;

namespace GamePlay.Modules.AI
{

    /// <summary>
    /// AI가 스폰 위치로 복귀하는 행동을 구현한 클래스입니다.
    /// </summary>
    public class ReturnToSpawnBehaviour : BehaviourBase<IReturnToSpawnBehaviourConfig, IFollowableAI>
    {
        Vector3 _spawnPosition;

        /// <summary>
        /// 복귀 행동의 생성자.
        /// </summary>
        /// <param name="config">복귀 행동 설정값.</param>
        /// <param name="ai">복귀 가능한 AI 객체.</param>
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


