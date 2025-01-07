using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// �Ƿε� ���¸� �����ϴ� �� Ŭ����.
    /// </summary>
    public class FatigueModel : DataDependantModelBase<IFatigueConfig, FatigueData>, IFatigueModel
    {
        float _bonusFatigue = 0;

        /// <summary>
        /// �ִ� �Ƿε� ��.
        /// </summary>
        public float MaxFatigue => Config.Fatigue + _bonusFatigue;

        /// <summary>
        /// ���� �Ƿε� ��.
        /// </summary>
        public float Fatigue => _data.Fatigue;

        /// <summary>
        /// �Ƿε� ��ȭ �� ȣ��Ǵ� �̺�Ʈ.
        /// </summary>
        public event Action OnFatigueChanged;
        public FatigueModel(IFatigueConfig config, FatigueData data) : base(config, data)
        {
            _data.SetFatigue(MaxFatigue);
        }

        /// <summary>
        /// �Ƿε��� ����/���ҽ�ŵ�ϴ�.
        /// </summary>
        public void AddFatigue(float amount)
        {
            _data.SetFatigue(Mathf.Clamp(_data.Fatigue + amount, 0, MaxFatigue));
            OnFatigueChanged?.Invoke();
        }

        /// <summary>
        /// �߰� �Ƿε��� �����մϴ�.
        /// </summary>
        public void AddBonusFatigue(float amount)
        {
            _bonusFatigue += amount;
            if(amount > 0)
                AddFatigue(amount);
        }
    }
}


