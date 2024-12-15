using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public class TransformMover : MoverBase, IUpdatable, IFixedUpdatable
    {
        Transform _transform;
        Space _space;
        public TransformMover(IMoverModel model, Transform transform, Space space) : base(model)
        {
            _transform = transform;
            _space = space;
        }

        public void OnFixedUpdate()
        {
            MoveOnUpdate(Time.fixedDeltaTime);
        }

        public void OnUpdate()
        {
            MoveOnUpdate(Time.deltaTime);
        }

        void MoveOnUpdate(float deltaTime)
        {
            if (!IsActive) return;

            if (_direction.magnitude < Util.EPSILON)
                return;

            
            _transform.Translate(_velocity * deltaTime, _space);
        }
    }

}
