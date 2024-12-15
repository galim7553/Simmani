using System.Collections;
using System.Collections.Generic;
using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Commands
{
    public interface ISansamCommandConfig : ICommandConfig
    {
        float ProcessAmount { get; }
        IProcessable.ProcessType ProcessType { get; }
        string SansamItemKey { get; }
        string NotSansamItemKey { get;}
    }
}


