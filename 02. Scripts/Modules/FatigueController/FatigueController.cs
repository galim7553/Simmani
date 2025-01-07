using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// �Ƿε��� �����ϰ� ���ҽ�Ű�� ��Ʈ�ѷ� Ŭ����.
    /// </summary>
    public class FatigueController : ModuleBase, IFatigueController, IUpdatable
    {
        IFatigueModel _model;

        /// <summary>
        /// �Ƿε��� 0�� �� �� ȣ��Ǵ� �̺�Ʈ.
        /// </summary>
        public event Action OnFatigueEmpty;
        public FatigueController(IFatigueModel model)
        {
            _model = model;
        }

        /// <summary>
        /// �� �����Ӹ��� ȣ��Ǿ� �Ƿε��� ������Ʈ�մϴ�.
        /// </summary>
        public void OnUpdate()
        {
            Update(Time.deltaTime);
        }

        void Update(float deltaTime)
        {
            if (!IsActive) return;

            // �Ƿε��� ���ҽ�Ű��, 0�� �Ǹ� �̺�Ʈ ȣ��
            _model.AddFatigue(-deltaTime * _model.Config.FatigueConsumptionSpeed);
            if (_model.Fatigue < Util.EPSILON)
                OnFatigueEmpty?.Invoke();
        }
    }
}


