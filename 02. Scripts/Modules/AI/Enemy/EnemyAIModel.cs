namespace GamePlay.Modules.AI
{
    /// <summary>
    /// �� AI�� ������ �� ����ü�Դϴ�.
    /// </summary>
    public class EnemyAIModel : ModuleModelBase<IEnemyAIConfig>, IEnemyAIModel, IFollowerModel
    {
        IFollowerConfig _followerConfig;
        IFollowerConfig IFollowerModel.Config => _followerConfig;

        /// <summary>�⺻ ȸ�� �ӵ�.</summary>
        float IFollowerModel.AngularSpeed => _followerConfig.BaseAngularSpeed;

        float _speedRatio = 1.0f;

        /// <summary>���� �̵� �ӵ�.</summary>
        public float Speed => Config.BaseSpeed * _speedRatio;

        /// <summary>
        /// �� AI �� ������.
        /// </summary>
        /// <param name="config">�� AI ������.</param>
        /// <param name="followerConfig">���� ���� ������.</param>
        public EnemyAIModel(IEnemyAIConfig config, IFollowerConfig followerConfig) : base(config)
        {
            _followerConfig = followerConfig;
        }

        /// <summary>
        /// �ӵ� ������ �����մϴ�.
        /// </summary>
        /// <param name="speedRaito">������ �ӵ� ����.</param>
        public void SetSpeedRaito(float speedRaito)
        {
            _speedRatio = speedRaito;
        }
    }
}