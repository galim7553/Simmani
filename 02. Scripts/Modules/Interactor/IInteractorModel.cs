using GamePlay.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IInteractorModel
    {
        ICommand Command { get; }
    }
}