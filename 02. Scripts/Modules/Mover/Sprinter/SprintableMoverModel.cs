using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 스프린트 가능한 이동 모듈의 런타임 데이터를 구현한 클래스.
    /// </summary>
    public class SprintableMoverModel : ModuleModelBase<ISprinterConfig>, ISprinterModel, IMoverModel
    {
        IMoverModel _moverModel;
        float _bonusStamina = 0;

        /// <summary>
        /// 현재 이동 속력. 스프린트 중이면 스프린트 속력 사용.
        /// </summary>
        public float Speed => IsSprinting ? Config.SprintSpeed : _moverModel.Speed;

        /// <summary>
        /// 현재 스프린트 여부.
        /// </summary>
        public bool IsSprinting { get; private set; }

        /// <summary>
        /// 최대 스태미너 값.
        /// </summary>
        public float MaxStamina => Config.Stamina + _bonusStamina;

        /// <summary>
        /// 현재 스태미너 값.
        /// </summary>
        public float Stamina { get; private set; }

        /// <summary>
        /// 스태미너 값 변경 이벤트.
        /// </summary>
        public event Action OnStaminaChanged;

        /// <summary>
        /// SprintableMoverModel 생성자.
        /// </summary>
        /// <param name="config">스프린트 설정</param>
        /// <param name="moverModel">이동 모듈</param>
        public SprintableMoverModel(ISprinterConfig config, IMoverModel moverModel) : base(config)
        {
            _moverModel = moverModel;
            Stamina = MaxStamina;
        }

        /// <summary>
        /// 스프린트 상태를 설정합니다.
        /// </summary>
        public void SetIsSprinting(bool isSprinting)
        {
            if (isSprinting == true && Stamina < Util.EPSILON) return;
            IsSprinting = isSprinting;
        }

        /// <summary>
        /// 스태미너 값을 추가합니다.
        /// </summary>
        public void AddStamina(float amount)
        {
            Stamina = Mathf.Clamp(Stamina + amount, 0, MaxStamina);
            if (Stamina < Util.EPSILON)
                IsSprinting = false;
            OnStaminaChanged?.Invoke();
        }

        /// <summary>
        /// 추가 스태미너 값을 설정합니다.
        /// </summary>
        public void AddBonusStamina(float amount)
        {
            _bonusStamina += amount;
            if (amount > 0)
                AddStamina(amount);
        }
    }
}