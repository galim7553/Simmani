using GamePlay.Configs;
using GamePlay.Factories;
using GamePlay.Modules;

namespace GamePlay.Hubs
{
    /// <summary>
    /// ���� �ֹ� ��.
    /// </summary>
    public class VillagerModel : HubModelBase<VillagerConfig>
    {
        public InteractorModel InteractorModel {  get; private set; } 
        public VillagerModel(VillagerConfig config, ICommandFactory commandFactory) : base(config)
        {
            InteractorModel = new InteractorModel(Config, commandFactory.CreateCommand(Config.CommandKey));
        }
    }
}


