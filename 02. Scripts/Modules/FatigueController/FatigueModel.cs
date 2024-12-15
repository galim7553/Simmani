using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public class FatigueModel : DataDependantModelBase<IFatigueConfig, FatigueData>, IFatigueModel
    {
        float _bonusFatigue = 0;
        public float MaxFatigue => Config.Fatigue + _bonusFatigue;
        public float Fatigue => _data.Fatigue;
        public event Action OnFatigueChanged;
        public FatigueModel(IFatigueConfig config, FatigueData data) : base(config, data)
        {
            _data.SetFatigue(MaxFatigue);
        }
        public void AddFatigue(float amount)
        {
            _data.SetFatigue(Mathf.Clamp(_data.Fatigue + amount, 0, MaxFatigue));
            OnFatigueChanged?.Invoke();
        }

        public void AddBonusFatigue(float amount)
        {
            _bonusFatigue += amount;
            if(amount > 0)
                AddFatigue(amount);
        }
    }
}


