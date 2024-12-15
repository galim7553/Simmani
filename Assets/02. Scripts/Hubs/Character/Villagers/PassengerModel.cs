using System.Collections;
using System.Collections.Generic;
using GamePlay.Configs;
using GamePlay.Factories;
using GamePlay.Modules;
using GamePlay.Modules.AI;
using UnityEngine;

namespace GamePlay.Hubs
{
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


