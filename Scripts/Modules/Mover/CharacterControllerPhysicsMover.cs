using GamePlay.Components;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// CharacterControllerPhysics를 사용하여 이동을 처리하는 클래스.
    /// </summary>
    public class CharacterControllerPhysicsMover : MoverBase, IFixedUpdatable
    {
        CharacterControllerPhysics _physics;
        Space _space;
        Vector3 _absoluteVelocity;

        /// <summary>
        /// CharacterControllerPhysicsMover 생성자.
        /// </summary>
        /// <param name="model">런타임 데이터를 관리하는 모델</param>
        /// <param name="physics">Physics 컴포넌트</param>
        /// <param name="space">이동 공간 (World 또는 Local)</param>
        public CharacterControllerPhysicsMover(IMoverModel model, CharacterControllerPhysics physics, Space space) : base(model)
        {
            _physics = physics;
            _space = space;
        }

        /// <summary>
        /// FixedUpdate 주기에 이동 처리.
        /// </summary>
        public void OnFixedUpdate()
        {
            if (!IsActive)
                _velocity = Vector3.zero;

            _velocity = _direction * _model.Speed;
            _absoluteVelocity = _space == Space.World ? _velocity : _physics.transform.TransformDirection(_velocity);

            _physics.SetVelocityX(_absoluteVelocity.x);
            _physics.SetVelocityZ(_absoluteVelocity.z);
        }

        public override void Clear()
        {
            base.Clear();
        }
    }
}