using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    [Serializable]
    public class SunInfo
    {
        [SerializeField] float _lightIntensity;
        [SerializeField] float _postExposure;
        [SerializeField] float _bloomIntensity;
        [SerializeField] Color _lightColor;

        public float LightIntensity => _lightIntensity;
        public float PostExposure => _postExposure;
        public float BloomIntensity => _bloomIntensity;
        public Color LightColor => _lightColor;
    }
}


