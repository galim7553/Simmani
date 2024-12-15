using GamePlay.Configs;
using GamePlay.Factories;
using GamePlay.Modules;

namespace GamePlay.Hubs
{
    public class InteractableObjectModel : HubModelBase<InteractableObjectConfig>
    {
        public InteractorModel InteractorModel { get; private set; }
        public InteractableObjectModel(InteractableObjectConfig config, ICommandFactory commandFactory) : base(config)
        {
            InteractorModel = new InteractorModel(Config, commandFactory.CreateCommand(Config.CommandKey));
        }
    }
}


