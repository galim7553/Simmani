using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public class RigidbodyMover : MoverBase, IFixedUpdatable
    {
        Rigidbody _rigidbody;
        Space _space;

        Vector3 _absoluteVelocity;

        public RigidbodyMover(IMoverModel model, Rigidbody rigidbody, Space space) : base(model)
        {
            _rigidbody = rigidbody;
            _space = space;
        }

        public void OnFixedUpdate()
        {
            if (!IsActive)
                _velocity = Vector3.zero;

            _velocity = _direction * _model.Speed;

            _absoluteVelocity = _space == Space.World ? _velocity : _rigidbody.transform.TransformDirection(_velocity);
            _rigidbody.velocity = _absoluteVelocity;
        }

        public override void Clear()
        {
            base.Clear();
        }
    }

}