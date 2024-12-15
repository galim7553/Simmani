using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public class SprintableMover : ModuleBase, ISprinter, IMover, IUpdatable
    {
        ISprinterModel _model;
        IMover _mover;

        public float Speed => _mover.Speed;

        public event Action<Vector3> OnDirectionChanged;

        public SprintableMover(ISprinterModel sprinterModel, IMover mover)
        {
            _model = sprinterModel;
            _mover = mover;

            _mover.OnDirectionChanged += OnMoverDirectionChanged;
        }

        public void SetDirection(float x, float y, float z)
        {
            if (!IsActive) return;

            _mover.SetDirection(x, y, z);
        }

        public void OnUpdate()
        {
            if (!IsActive) return;

            if (Speed > Util.EPSILON && _model.IsSprinting)
                _model.AddStamina(-Time.deltaTime * _model.Config.StaminaConsumptionSpeed);
            else
                _model.AddStamina(Time.deltaTime * _model.Config.StaminaRecoverySpeed);
        }

        void OnMoverDirectionChanged(Vector3 direction)
        {
            OnDirectionChanged?.Invoke(direction);
        }

        public void SetIsSprinting(bool isSprinting)
        {
            if (!IsActive) return;

            _model.SetIsSprinting(isSprinting);
        }

        public override void Clear()
        {
            base.Clear();

            _mover.OnDirectionChanged -= OnMoverDirectionChanged;
            OnDirectionChanged = null;

            _mover.Clear();
        }
    }

}
