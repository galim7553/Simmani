using GamePlay.Configs;
using GamePlay.Factories;
using GamePlay.Modules;
using GamePlay.Modules.AI;

namespace GamePlay.Hubs
{
    /// <summary>
    /// ����(Passenger)�� ���� ��Ÿ���ϴ�.
    /// ��ȣ�ۿ� �� �� AI ���� �����մϴ�.
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


