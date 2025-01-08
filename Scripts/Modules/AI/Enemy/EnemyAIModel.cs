namespace GamePlay.Modules.AI
{
    /// <summary>
    /// 적 AI의 데이터 모델 구현체입니다.
    /// </summary>
    public class EnemyAIModel : ModuleModelBase<IEnemyAIConfig>, IEnemyAIModel, IFollowerModel
    {
        IFollowerConfig _followerConfig;
        IFollowerConfig IFollowerModel.Config => _followerConfig;

        /// <summary>기본 회전 속도.</summary>
        float IFollowerModel.AngularSpeed => _followerConfig.BaseAngularSpeed;

        float _speedRatio = 1.0f;

        /// <summary>현재 이동 속도.</summary>
        public float Speed => Config.BaseSpeed * _speedRatio;

        /// <summary>
        /// 적 AI 모델 생성자.
        /// </summary>
        /// <param name="config">적 AI 설정값.</param>
        /// <param name="followerConfig">추적 동작 설정값.</param>
        public EnemyAIModel(IEnemyAIConfig config, IFollowerConfig followerConfig) : base(config)
        {
            _followerConfig = followerConfig;
        }

        /// <summary>
        /// 속도 비율을 설정합니다.
        /// </summary>
        /// <param name="speedRaito">적용할 속도 비율.</param>
        public void SetSpeedRaito(float speedRaito)
        {
            _speedRatio = speedRaito;
        }
    }
}