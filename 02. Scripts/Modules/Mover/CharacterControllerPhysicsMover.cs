using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Components;
using UnityEngine;

namespace GamePlay.Modules
{
    public class CharacterControllerPhysicsMover : MoverBase, IFixedUpdatable
    {
        CharacterControllerPhysics _physics;
        Space _space;

        Vector3 _absoluteVelocity;

        public CharacterControllerPhysicsMover(IMoverModel model, CharacterControllerPhysics physics, Space space) : base(model)
        {
            _physics = physics;
            _space = space;
        }

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

