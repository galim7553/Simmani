using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// �̵� ����� �⺻ ������ ����ϴ� �߻� Ŭ����.
    /// </summary>
    public abstract class MoverBase : ModuleBase, IMover
    {
        protected IMoverModel _model;

        /// <summary>
        /// ������ ����� �� �߻��ϴ� �̺�Ʈ.
        /// </summary>
        public event Action<Vector3> OnDirectionChanged;

        Vector3 _inputDirection = Vector3.zero; // �Է� ����
        protected Vector3 _direction = Vector3.zero; // ���� �̵� ����
        protected Vector3 _velocity = Vector3.zero; // �ӵ� ����

        /// <summary>
        /// ���� �̵� �ӵ�.
        /// </summary>
        public float Speed => _velocity.magnitude;

        /// <summary>
        /// MoverBase ������.
        /// </summary>
        /// <param name="model">��Ÿ�� �����͸� �����ϴ� ��</param>
        public MoverBase(IMoverModel model)
        {
            _model = model;
        }

        /// <summary>
        /// �̵� ������ �����մϴ�.
        /// </summary>
        /// <param name="x">x�� ����</param>
        /// <param name="y">y�� ����</param>
        /// <param name="z">z�� ����</param>
        public void SetDirection(float x, float y, float z)
        {
            if (!IsActive) return;

            _inputDirection.x = x;
            _inputDirection.y = y;
            _inputDirection.z = z;

            // �Է� ���� ����ȭ �� ��ȿ�� �˻�
            float inputDirectionMagnitude = _inputDirection.magnitude;
            if (inputDirectionMagnitude < Util.EPSILON)
                _inputDirection = Vector3.zero;
            else if (inputDirectionMagnitude > 1.0f)
                _inputDirection.Normalize();

            if (Mathf.Abs(_inputDirection.x - _direction.x) < Util.EPSILON
                && Mathf.Abs(_inputDirection.y - _direction.y) < Util.EPSILON
                && Mathf.Abs(_inputDirection.z - _direction.z) < Util.EPSILON)
                return;

            _direction = _inputDirection;
            OnDirectionChanged?.Invoke(_direction); // ���� ���� �̺�Ʈ ȣ��
        }

        /// <summary>
        /// ����� ���¸� �ʱ�ȭ�մϴ�.
        /// </summary>
        public override void Clear()
        {
            OnDirectionChanged = null;
        }
    }
}