using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// Transform�� ������� �̵��� ó���ϴ� Ŭ����.
    /// </summary>
    public class TransformMover : MoverBase, IUpdatable, IFixedUpdatable
    {
        Transform _transform;
        Space _space;

        /// <summary>
        /// TransformMover ������.
        /// </summary>
        /// <param name="model">��Ÿ�� �����͸� �����ϴ� ��</param>
        /// <param name="transform">�̵��� Transform</param>
        /// <param name="space">�̵� ���� (World �Ǵ� Local)</param>
        public TransformMover(IMoverModel model, Transform transform, Space space) : base(model)
        {
            _transform = transform;
            _space = space;
        }

        /// <summary>
        /// FixedUpdate �ֱ⿡ �̵� ó��.
        /// </summary>
        public void OnFixedUpdate()
        {
            MoveOnUpdate(Time.fixedDeltaTime);
        }

        /// <summary>
        /// Update �ֱ⿡ �̵� ó��.
        /// </summary>
        public void OnUpdate()
        {
            MoveOnUpdate(Time.deltaTime);
        }

        /// <summary>
        /// �̵� ������ ó���մϴ�.
        /// </summary>
        /// <param name="deltaTime">������ �� �ð�</param>
        void MoveOnUpdate(float deltaTime)
        {
            if (!IsActive || _direction.magnitude < Util.EPSILON) return;

            _transform.Translate(_velocity * deltaTime, _space);
        }
    }
}