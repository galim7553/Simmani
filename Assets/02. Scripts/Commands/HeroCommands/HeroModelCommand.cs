using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Commands
{
    public abstract class HeroModelCommandBase : IHeroModelCommand
    {
        protected IHeroModelCommandConfig _config;
        public HeroModelCommandBase(IHeroModelCommandConfig config)
        {
            _config = config;
        }

        public abstract void Apply(IHeroModel target);
        public abstract void Disapply(IHeroModel target);
    }
    public class HeroModelCommand : HeroModelCommandBase, IAppliableCommand<IHeroModel>
    {
        public HeroModelCommand(IHeroModelCommandConfig config) : base(config)
        {
        }

        public override void Apply(IHeroModel target)
        {
            target.ExecuteCommand(_config.Type, _config.Amount);
        }

        public override void Disapply(IHeroModel target)
        {
            target.ExecuteCommand(_config.Type, -_config.Amount);
        }
    }
}


