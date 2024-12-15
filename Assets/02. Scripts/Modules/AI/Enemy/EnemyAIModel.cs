using System.Collections.Generic;

namespace GamePlay.Modules.AI
{
    public class EnemyAIModel : ModuleModelBase<IEnemyAIConfig>, IEnemyAIModel, IFollowerModel
    {
        IFollowerConfig _followerConfig;
        IFollowerConfig IFollowerModel.Config => _followerConfig;
        float IFollowerModel.AngularSpeed => _followerConfig.BaseAngularSpeed;
        float IFollowerModel.RotSpeed => _followerConfig.BaseRotSpeed;

        float _speedRatio = 1.0f;
        public float Speed => Config.BaseSpeed * _speedRatio;

        public EnemyAIModel(IEnemyAIConfig config, IFollowerConfig followerConfig) : base(config)
        {
            _followerConfig = followerConfig;
        }
        public void SetSpeedRaito(float speedRaito)
        {
            _speedRatio = speedRaito;
        }
    }
}