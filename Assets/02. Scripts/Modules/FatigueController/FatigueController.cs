using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public class FatigueController : ModuleBase, IFatigueController, IUpdatable
    {
        IFatigueModel _model;
        public event Action OnFatigueEmpty;
        public FatigueController(IFatigueModel model)
        {
            _model = model;
        }
        public void OnUpdate()
        {
            Update(Time.deltaTime);
        }

        void Update(float deltaTime)
        {
            if (!IsActive) return;

            _model.AddFatigue(-deltaTime * _model.Config.FatigueConsumptionSpeed);
            if (_model.Fatigue < Util.EPSILON)
                OnFatigueEmpty?.Invoke();
        }
    }
}


