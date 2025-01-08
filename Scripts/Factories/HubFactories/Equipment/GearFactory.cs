using GamePlay.Configs;
using GamePlay.Hubs;
using GamePlay.Hubs.Equipments;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Factories
{
    public class GearFactory : FactoryBase<Gear, GearModel>
    {
        ILightController _lightController;
        public GearFactory(PoolManager poolManager, ILightController lightController) : base(poolManager)
        {
            _lightController = lightController;
        }

        public override Gear Create(GearModel model)
        {
            Gear gear = _poolManager.GetFromPool(model.PrefabPath).GetOrAddComponent<Gear>();

            if(gear is Torch torch)
                torch.SetLightController(_lightController);

            gear.SetModel(model);

            gear.Initialize();
            return gear;
        }
    }
}


