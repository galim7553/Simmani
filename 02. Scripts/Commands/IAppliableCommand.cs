using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Commands
{
    public interface IAppliableCommand<T> : ICommand
    {
        void Apply(T target);
        void Disapply(T target);
    }
}


