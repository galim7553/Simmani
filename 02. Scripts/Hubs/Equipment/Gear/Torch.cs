using GamePlay.Hubs.Equipments;
using UnityEngine;

namespace GamePlay.Hubs
{
    /// <summary>
    /// ȶ��(Torch) ��� Ŭ����. ���� ������ �����ϴ� ��� ����.
    /// </summary>
    public class Torch : Gear
    {
        Light _light; // ȶ���� ��
        ILightController _lightController; // ���� ���� �������̽�
        float _maxIntensity; // ȶ�� ����Ʈ�� �ִ� ���

        private void Awake()
        {
            _light = GetComponentInChildren<Light>(); // �ڽ� ������Ʈ���� Light ������Ʈ �˻�
            _maxIntensity = _light.intensity; // �ʱ� ��⸦ �ִ� ���� ����
        }

        /// <summary>
        /// �� ����⸦ �����մϴ�.
        /// </summary>
        /// <param name="lightController">�� ����� �������̽�</param>
        public void SetLightController(ILightController lightController)
        {
            _lightController = lightController;
            _light.intensity = (1 - _lightController.NormalizedIntensity) * _maxIntensity;
        }

        private void Update()
        {
            // �� ������� ���¿� ���� ��� ����
            if (_lightController != null)
                _light.intensity = (1 - _lightController.NormalizedIntensity) * _maxIntensity;
        }
    }
}

