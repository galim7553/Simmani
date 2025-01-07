using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// ������Ʈ ������ �̵� ����� ������ Ŭ����.
    /// </summary>
    public class SprintableMover : ModuleBase, ISprinter, IMover, IUpdatable
    {
        ISprinterModel _model;
        IMover _mover;

        /// <summary>
        /// ���� �̵� �ӷ�.
        /// </summary>
        public float Speed => _mover.Speed;

        /// <summary>
        /// ������ ����� �� ȣ��Ǵ� �̺�Ʈ.
        /// </summary>
        public event Action<Vector3> OnDirectionChanged;

        /// <summary>
        /// SprintableMover ������.
        /// </summary>
        public SprintableMover(ISprinterModel sprinterModel, IMover mover)
        {
            _model = sprinterModel;
            _mover = mover;

            _mover.OnDirectionChanged += OnMoverDirectionChanged;
        }

        /// <summary>
        /// �̵� ������ �����մϴ�.
        /// </summary>
        public void SetDirection(float x, float y, float z)
        {
            if (!IsActive) return;

            _mover.SetDirection(x, y, z);
        }

        /// <summary>
        /// Update �ֱ⿡�� ���¹̳� ���� �� �̵� ���¸� ó���մϴ�.
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
        /// ���� ���� �̺�Ʈ �ڵ鷯.
        /// </summary>
        void OnMoverDirectionChanged(Vector3 direction)
        {
            OnDirectionChanged?.Invoke(direction);
        }

        /// <summary>
        /// ������Ʈ ���¸� �����մϴ�.
        /// </summary>
        public void SetIsSprinting(bool isSprinting)
        {
            if (!IsActive) return;

            _model.SetIsSprinting(isSprinting);
        }

        /// <summary>
        /// ��� �ʱ�ȭ �� �̺�Ʈ �ڵ鷯 ����.
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
