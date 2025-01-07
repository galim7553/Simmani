
namespace GamePlay.Modules.AI
{
    /// <summary>
    /// AI의 추적 행동을 구현한 클래스입니다.
    /// </summary>
    public class TraceBehaviour : BehaviourBase<ITraceBehaviourConfig, ITargetFollowableAI>
    {

        /// <summary>
        /// 추적 행동의 생성자.
        /// </summary>
        /// <param name="config">추적 행동 설정값.</param>
        /// <param name="ai">추적 가능한 AI 객체.</param>
        public TraceBehaviour(ITraceBehaviourConfig config, ITargetFollowableAI ai) : base(config, ai)
        {
        }

        public override void Enter()
        {
            _ai.Model.SetSpeedRaito(_config.SpeedRatio);
            _ai.FollowTarget(_ai.Target);

            _ai.OnTargetChanged += FollowTarget;
        }

        void FollowTarget()
        {
            _ai.FollowTarget(_ai.Target);
        }

        public override void Exit()
        {
            _ai.Unfollow();

            _ai.OnTargetChanged -= FollowTarget;
        }
    }
}