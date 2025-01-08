
namespace GamePlay.Modules.AI
{
    /// <summary>
    /// AI�� ���� �ൿ�� ������ Ŭ�����Դϴ�.
    /// </summary>
    public class TraceBehaviour : BehaviourBase<ITraceBehaviourConfig, ITargetFollowableAI>
    {

        /// <summary>
        /// ���� �ൿ�� ������.
        /// </summary>
        /// <param name="config">���� �ൿ ������.</param>
        /// <param name="ai">���� ������ AI ��ü.</param>
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