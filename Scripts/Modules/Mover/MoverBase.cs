using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 이동 모듈의 기본 구현을 담당하는 추상 클래스.
    /// </summary>
    public abstract class MoverBase : ModuleBase, IMover
    {
        protected IMoverModel _model;

        /// <summary>
        /// 방향이 변경될 때 발생하는 이벤트.
        /// </summary>
        public event Action<Vector3> OnDirectionChanged;

        Vector3 _inputDirection = Vector3.zero; // 입력 방향
        protected Vector3 _direction = Vector3.zero; // 실제 이동 방향
        protected Vector3 _velocity = Vector3.zero; // 속도 벡터

        /// <summary>
        /// 현재 이동 속도.
        /// </summary>
        public float Speed => _velocity.magnitude;

        /// <summary>
        /// MoverBase 생성자.
        /// </summary>
        /// <param name="model">런타임 데이터를 관리하는 모델</param>
        public MoverBase(IMoverModel model)
        {
            _model = model;
        }

        /// <summary>
        /// 이동 방향을 설정합니다.
        /// </summary>
        /// <param name="x">x축 방향</param>
        /// <param name="y">y축 방향</param>
        /// <param name="z">z축 방향</param>
        public void SetDirection(float x, float y, float z)
        {
            if (!IsActive) return;

            _inputDirection.x = x;
            _inputDirection.y = y;
            _inputDirection.z = z;

            // 입력 방향 정규화 및 유효성 검사
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
            OnDirectionChanged?.Invoke(_direction); // 방향 변경 이벤트 호출
        }

        /// <summary>
        /// 모듈의 상태를 초기화합니다.
        /// </summary>
        public override void Clear()
        {
            OnDirectionChanged = null;
        }
    }
}