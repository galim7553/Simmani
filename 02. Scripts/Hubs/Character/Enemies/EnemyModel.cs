using GamePlay.Configs;
using GamePlay.Modules;
using GamePlay.Modules.AI;

namespace GamePlay.Hubs
{
    /// <summary>
    /// ��(Enemy)�� �� Ŭ����.
    /// ���� AI, ������ �ۼ���, Ÿ�� Ž�� �� ���� �����մϴ�.
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
        /// EnemyModel ������.
        /// </summary>
        /// <param name="config">EnemyConfig ��ü.</param>
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


