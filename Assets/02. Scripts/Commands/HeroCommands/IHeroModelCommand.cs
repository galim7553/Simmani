using GamePlay.Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Commands
{
    public interface IHeroModelCommand : IAppliableCommand<IHeroModel>, IItemUsage
    {

    }
}