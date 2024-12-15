using GamePlay.Configs;
using GamePlay.Modules;
using GamePlay.Modules.AI;

namespace GamePlay.Hubs
{
    public class EnemyModel : HubModelBase<EnemyConfig>
    {
        static int _idCounter = 0;

        public int Id { get; private set; }
        public DamageReceiverModel DamageReceiverModel { get; private set; }
        public DamageSenderModel DamageSenderModel { get; private set; }
        public EnemyAIModel EnemyAIModel { get; private set; }
        public TargetFinderModel TargetFinderModel { get; private set; }


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


