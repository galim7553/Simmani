using System;
using UnityEngine;

namespace GamePlay.Modules
{
    public abstract class MoverBase : ModuleBase, IMover
    {
        protected IMoverModel _model;

        public event Action<Vector3> OnDirectionChanged;

        Vector3 _inputDirection = Vector3.zero;
        protected Vector3 _direction = Vector3.zero;
        protected Vector3 _velocity = Vector3.zero;

        public float Speed => _velocity.magnitude;

        public MoverBase(IMoverModel model)
        {
            _model = model;
        }

        public void SetDirection(float x, float y, float z)
        {
            if (!IsActive) return;

            _inputDirection.x = x;
            _inputDirection.y = y;
            _inputDirection.z = z;

            float inputDirectionMagnitude = _inputDirection.magnitude;
            // _inputDirection�� 0�� ������ _inputDirection�� Vector3.zero�� ����
            if (inputDirectionMagnitude < Util.EPSILON)
                _inputDirection = Vector3.zero;

            // _inputDirection�� ũ�Ⱑ 1���� ũ�� ����ȭ
            else if (inputDirectionMagnitude > 1.0f)
                _inputDirection.Normalize();

            // ���� ����(_direction)�� ���ο� ����(_inputDirection)�� ���� ������ ����
            if (Mathf.Abs(_inputDirection.x - _direction.x) < Util.EPSILON
                && Mathf.Abs(_inputDirection.y - _direction.y) < Util.EPSILON
                && Mathf.Abs(_inputDirection.z - _direction.z) < Util.EPSILON)
                return;

            // �� ���� ����
            _direction = _inputDirection;

            // ���� ��ȭ �̺�Ʈ ȣ��
            OnDirectionChanged?.Invoke(_direction);
        }

        public override void Clear()
        {
            OnDirectionChanged = null;
        }
    }
}