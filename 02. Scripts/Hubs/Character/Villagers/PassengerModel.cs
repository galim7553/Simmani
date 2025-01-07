using GamePlay.Configs;
using GamePlay.Factories;
using GamePlay.Modules;
using GamePlay.Modules.AI;

namespace GamePlay.Hubs
{
    /// <summary>
    /// 행인(Passenger)의 모델을 나타냅니다.
    /// 상호작용 모델 및 AI 모델을 포함합니다.
    public class PassengerModel : HubModelBase<PassengerConfig>
    {
        public InteractorModel InteractorModel { get; private set; }
        public PassengerAIModel PassengerAIModel { get; private set; }
        public PassengerModel(PassengerConfig config, ICommandFactory commandFactory) : base(config)
        {
            InteractorModel = new InteractorModel(Config, commandFactory.CreateCommand(Config.CommandKey));
            PassengerAIModel = new PassengerAIModel(Config, Config);
        }

        
    }
}


