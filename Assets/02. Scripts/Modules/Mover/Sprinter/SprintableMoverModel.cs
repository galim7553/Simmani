using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public class SprintableMoverModel : ModuleModelBase<ISprinterConfig>, ISprinterModel, IMoverModel
    {
        IMoverModel _moverModel;
        float _bonusStamina = 0;
        public float Speed => IsSprinting ? Config.SprintSpeed : _moverModel.Speed;
        public bool IsSprinting {get; private set;}
        public float MaxStamina => Config.Stamina + _bonusStamina;
        public float Stamina {get; private set;}

        public event Action OnStaminaChanged;

        public SprintableMoverModel(ISprinterConfig config, IMoverModel moverModel) : base(config)
        {
            _moverModel = moverModel;
            Stamina = MaxStamina;
        }

        public void SetIsSprinting(bool isSprinting)
        {
            if (isSprinting == true && Stamina < Util.EPSILON) return;
            
            IsSprinting = isSprinting;
        }

        public void AddStamina(float amount)
        {
            Stamina = Mathf.Clamp(Stamina + amount, 0, MaxStamina);
            if (Stamina < Util.EPSILON)
                IsSprinting = false;
            OnStaminaChanged?.Invoke();
        }

        public void AddBonusStamina(float amount)
        {
            _bonusStamina += amount;
            if(amount > 0)
                AddStamina(amount);
        }
    }
}


