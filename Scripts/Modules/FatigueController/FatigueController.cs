using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 피로도를 관리하고 감소시키는 컨트롤러 클래스.
    /// </summary>
    public class FatigueController : ModuleBase, IFatigueController, IUpdatable
    {
        IFatigueModel _model;

        /// <summary>
        /// 피로도가 0이 될 때 호출되는 이벤트.
        /// </summary>
        public event Action OnFatigueEmpty;
        public FatigueController(IFatigueModel model)
        {
            _model = model;
        }

        /// <summary>
        /// 매 프레임마다 호출되어 피로도를 업데이트합니다.
        /// </summary>
        public void OnUpdate()
        {
            Update(Time.deltaTime);
        }

        void Update(float deltaTime)
        {
            if (!IsActive) return;

            // 피로도를 감소시키고, 0이 되면 이벤트 호출
            _model.AddFatigue(-deltaTime * _model.Config.FatigueConsumptionSpeed);
            if (_model.Fatigue < Util.EPSILON)
                OnFatigueEmpty?.Invoke();
        }
    }
}


