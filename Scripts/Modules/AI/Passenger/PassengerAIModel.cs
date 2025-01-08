using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules.AI
{
    public class PassengerAIModel : ModuleModelBase<IPassengerAIConfig>, IPassengerAIModel, IFollowerModel
    {
        IFollowerConfig _followerConfig;
        IFollowerConfig IFollowerModel.Config => _followerConfig;
        float IFollowerModel.AngularSpeed => _followerConfig.BaseAngularSpeed;
        public float Speed => Config.BaseSpeed;

        public PassengerAIModel(IPassengerAIConfig config, IFollowerConfig followerConfig) : base(config)
        {
            _followerConfig = followerConfig;
        }



        public void SetSpeedRaito(float speedRaito)
        {
        }
    }

}

