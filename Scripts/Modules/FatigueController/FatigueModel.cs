using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 피로도 상태를 관리하는 모델 클래스.
    /// </summary>
    public class FatigueModel : DataDependantModelBase<IFatigueConfig, FatigueData>, IFatigueModel
    {
        float _bonusFatigue = 0;

        /// <summary>
        /// 최대 피로도 값.
        /// </summary>
        public float MaxFatigue => Config.Fatigue + _bonusFatigue;

        /// <summary>
        /// 현재 피로도 값.
        /// </summary>
        public float Fatigue => _data.Fatigue;

        /// <summary>
        /// 피로도 변화 시 호출되는 이벤트.
        /// </summary>
        public event Action OnFatigueChanged;
        public FatigueModel(IFatigueConfig config, FatigueData data) : base(config, data)
        {
            _data.SetFatigue(MaxFatigue);
        }

        /// <summary>
        /// 피로도를 증가/감소시킵니다.
        /// </summary>
        public void AddFatigue(float amount)
        {
            _data.SetFatigue(Mathf.Clamp(_data.Fatigue + amount, 0, MaxFatigue));
            OnFatigueChanged?.Invoke();
        }

        /// <summary>
        /// 추가 피로도를 설정합니다.
        /// </summary>
        public void AddBonusFatigue(float amount)
        {
            _bonusFatigue += amount;
            if(amount > 0)
                AddFatigue(amount);
        }
    }
}


