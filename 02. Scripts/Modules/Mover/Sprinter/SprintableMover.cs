using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 스프린트 가능한 이동 모듈을 구현한 클래스.
    /// </summary>
    public class SprintableMover : ModuleBase, ISprinter, IMover, IUpdatable
    {
        ISprinterModel _model;
        IMover _mover;

        /// <summary>
        /// 현재 이동 속력.
        /// </summary>
        public float Speed => _mover.Speed;

        /// <summary>
        /// 방향이 변경될 때 호출되는 이벤트.
        /// </summary>
        public event Action<Vector3> OnDirectionChanged;

        /// <summary>
        /// SprintableMover 생성자.
        /// </summary>
        public SprintableMover(ISprinterModel sprinterModel, IMover mover)
        {
            _model = sprinterModel;
            _mover = mover;

            _mover.OnDirectionChanged += OnMoverDirectionChanged;
        }

        /// <summary>
        /// 이동 방향을 설정합니다.
        /// </summary>
        public void SetDirection(float x, float y, float z)
        {
            if (!IsActive) return;

            _mover.SetDirection(x, y, z);
        }

        /// <summary>
        /// Update 주기에서 스태미너 관리 및 이동 상태를 처리합니다.
        /// </summary>
        public void OnUpdate()
        {
            if (!IsActive) return;

            if (Speed > Util.EPSILON && _model.IsSprinting)
                _model.AddStamina(-Time.deltaTime * _model.Config.StaminaConsumptionSpeed);
            else
                _model.AddStamina(Time.deltaTime * _model.Config.StaminaRecoverySpeed);
        }

        /// <summary>
        /// 방향 변경 이벤트 핸들러.
        /// </summary>
        void OnMoverDirectionChanged(Vector3 direction)
        {
            OnDirectionChanged?.Invoke(direction);
        }

        /// <summary>
        /// 스프린트 상태를 설정합니다.
        /// </summary>
        public void SetIsSprinting(bool isSprinting)
        {
            if (!IsActive) return;

            _model.SetIsSprinting(isSprinting);
        }

        /// <summary>
        /// 모듈 초기화 및 이벤트 핸들러 해제.
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            _mover.OnDirectionChanged -= OnMoverDirectionChanged;
            OnDirectionChanged = null;

            _mover.Clear();
        }
    }
}
