using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// ������Ʈ ������ �̵� ����� ��Ÿ�� �����͸� ������ Ŭ����.
    /// </summary>
    public class SprintableMoverModel : ModuleModelBase<ISprinterConfig>, ISprinterModel, IMoverModel
    {
        IMoverModel _moverModel;
        float _bonusStamina = 0;

        /// <summary>
        /// ���� �̵� �ӷ�. ������Ʈ ���̸� ������Ʈ �ӷ� ���.
        /// </summary>
        public float Speed => IsSprinting ? Config.SprintSpeed : _moverModel.Speed;

        /// <summary>
        /// ���� ������Ʈ ����.
        /// </summary>
        public bool IsSprinting { get; private set; }

        /// <summary>
        /// �ִ� ���¹̳� ��.
        /// </summary>
        public float MaxStamina => Config.Stamina + _bonusStamina;

        /// <summary>
        /// ���� ���¹̳� ��.
        /// </summary>
        public float Stamina { get; private set; }

        /// <summary>
        /// ���¹̳� �� ���� �̺�Ʈ.
        /// </summary>
        public event Action OnStaminaChanged;

        /// <summary>
        /// SprintableMoverModel ������.
        /// </summary>
        /// <param name="config">������Ʈ ����</param>
        /// <param name="moverModel">�̵� ���</param>
        public SprintableMoverModel(ISprinterConfig config, IMoverModel moverModel) : base(config)
        {
            _moverModel = moverModel;
            Stamina = MaxStamina;
        }

        /// <summary>
        /// ������Ʈ ���¸� �����մϴ�.
        /// </summary>
        public void SetIsSprinting(bool isSprinting)
        {
            if (isSprinting == true && Stamina < Util.EPSILON) return;
            IsSprinting = isSprinting;
        }

        /// <summary>
        /// ���¹̳� ���� �߰��մϴ�.
        /// </summary>
        public void AddStamina(float amount)
        {
            Stamina = Mathf.Clamp(Stamina + amount, 0, MaxStamina);
            if (Stamina < Util.EPSILON)
                IsSprinting = false;
            OnStaminaChanged?.Invoke();
        }

        /// <summary>
        /// �߰� ���¹̳� ���� �����մϴ�.
        /// </summary>
        public void AddBonusStamina(float amount)
        {
            _bonusStamina += amount;
            if (amount > 0)
                AddStamina(amount);
        }
    }
}