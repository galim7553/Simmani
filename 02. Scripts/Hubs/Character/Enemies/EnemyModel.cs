using GamePlay.Configs;
using GamePlay.Modules;
using GamePlay.Modules.AI;

namespace GamePlay.Hubs
{
    /// <summary>
    /// 적(Enemy)의 모델 클래스.
    /// 적의 AI, 데미지 송수신, 타겟 탐지 모델 등을 관리합니다.
    /// </summary>
    public class EnemyModel : HubModelBase<EnemyConfig>
    {
        static int _idCounter = 0;

        public int Id { get; private set; }
        public DamageReceiverModel DamageReceiverModel { get; private set; }
        public DamageSenderModel DamageSenderModel { get; private set; }
        public EnemyAIModel EnemyAIModel { get; private set; }
        public TargetFinderModel TargetFinderModel { get; private set; }

        /// <summary>
        /// EnemyModel 생성자.
        /// </summary>
        /// <param name="config">EnemyConfig 객체.</param>
        public EnemyModel(EnemyConfig config) : base(config)
        {
            Id = _idCounter;
            _idCounter++;

            DamageReceiverModel = new DamageReceiverModel(Config);
            DamageSenderModel = new DamageSenderModel(Config);
            EnemyAIModel = new EnemyAIModel(Config, Config);
            TargetFinderModel = new TargetFinderModel(Config);
        }
    }
}


