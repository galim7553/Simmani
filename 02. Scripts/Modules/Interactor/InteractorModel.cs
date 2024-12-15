using GamePlay.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public class InteractorModel : ModuleModelBase<IInteractorConfig>, IInteractorModel
    {
        public ICommand Command { get; private set; }
        public InteractorModel(IInteractorConfig config, ICommand command) : base(config)
        {
            Command = command;
        }
    }
}


