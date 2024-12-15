using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IFollowerModel
    {
        IFollowerConfig Config { get; }
        float Speed { get; }
        float AngularSpeed { get; }
        float RotSpeed { get; }
    }

}