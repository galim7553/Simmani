using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// Transform을 기반으로 이동을 처리하는 클래스.
    /// </summary>
    public class TransformMover : MoverBase, IUpdatable, IFixedUpdatable
    {
        Transform _transform;
        Space _space;

        /// <summary>
        /// TransformMover 생성자.
        /// </summary>
        /// <param name="model">런타임 데이터를 관리하는 모델</param>
        /// <param name="transform">이동할 Transform</param>
        /// <param name="space">이동 공간 (World 또는 Local)</param>
        public TransformMover(IMoverModel model, Transform transform, Space space) : base(model)
        {
            _transform = transform;
            _space = space;
        }

        /// <summary>
        /// FixedUpdate 주기에 이동 처리.
        /// </summary>
        public void OnFixedUpdate()
        {
            MoveOnUpdate(Time.fixedDeltaTime);
        }

        /// <summary>
        /// Update 주기에 이동 처리.
        /// </summary>
        public void OnUpdate()
        {
            MoveOnUpdate(Time.deltaTime);
        }

        /// <summary>
        /// 이동 로직을 처리합니다.
        /// </summary>
        /// <param name="deltaTime">프레임 간 시간</param>
        void MoveOnUpdate(float deltaTime)
        {
            if (!IsActive || _direction.magnitude < Util.EPSILON) return;

            _transform.Translate(_velocity * deltaTime, _space);
        }
    }
}