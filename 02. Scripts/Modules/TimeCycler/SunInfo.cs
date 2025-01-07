using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// �¾��� ���� ���� �� ȯ�� ������ ��� ������ Ŭ����.
    /// </summary>
    [Serializable]
    public class SunInfo
    {
        [SerializeField] float _lightIntensity;
        [SerializeField] float _postExposure;
        [SerializeField] float _bloomIntensity;
        [SerializeField] Color _lightColor;

        /// <summary>�¾籤�� ����.</summary>
        public float LightIntensity => _lightIntensity;

        /// <summary>����Ʈ ���μ��� ���� ��.</summary>
        public float PostExposure => _postExposure;

        /// <summary>Bloom ȿ�� ����.</summary>
        public float BloomIntensity => _bloomIntensity;

        /// <summary>�¾籤�� ����.</summary>
        public Color LightColor => _lightColor;
    }
}


