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
            // _inputDirection이 0에 가까우면 _inputDirection을 Vector3.zero로 간주
            if (inputDirectionMagnitude < Util.EPSILON)
                _inputDirection = Vector3.zero;

            // _inputDirection의 크기가 1보다 크면 정규화
            else if (inputDirectionMagnitude > 1.0f)
                _inputDirection.Normalize();

            // 기존 방향(_direction)과 새로운 방향(_inputDirection)이 거의 같으면 리턴
            if (Mathf.Abs(_inputDirection.x - _direction.x) < Util.EPSILON
                && Mathf.Abs(_inputDirection.y - _direction.y) < Util.EPSILON
                && Mathf.Abs(_inputDirection.z - _direction.z) < Util.EPSILON)
                return;

            // 새 방향 갱신
            _direction = _inputDirection;

            // 방향 변화 이벤트 호출
            OnDirectionChanged?.Invoke(_direction);
        }

        public override void Clear()
        {
            OnDirectionChanged = null;
        }
    }
}