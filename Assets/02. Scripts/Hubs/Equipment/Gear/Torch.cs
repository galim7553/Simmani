using System.Collections;
using System.Collections.Generic;
using GamePlay.Hubs.Equipments;
using UnityEngine;

namespace GamePlay.Hubs
{
    public class Torch : Gear
    {
        Light _light;
        ILightController _lightController;
        float _maxIntensity;

        private void Awake()
        {
            _light = GetComponentInChildren<Light>();
            _maxIntensity = _light.intensity;
        }

        public void SetLightController(ILightController lightController)
        {
            _lightController = lightController;
            _light.intensity = (1 - _lightController.NormalizedIntensity) * _maxIntensity;
        }

        private void Update()
        {
            if (_lightController != null)
                _light.intensity = (1 - _lightController.NormalizedIntensity) * _maxIntensity;
        }
    }
}

