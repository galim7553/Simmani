using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GamePlay.Modules
{
    public class TransformRotator : ModuleBase, IRotator, IUpdatable, IFixedUpdatable
    {
        IRotatorModel _model;
        Transform _transform;

        float[] _rots = new float[] { 0.0f, 0.0f, 0.0f };

        Quaternion _rotation;
        Vector3 _euler;


        public TransformRotator(IRotatorModel model, Transform transform)
        {
            _model = model;
            _transform = transform;
        }

        public void OnUpdate()
        {
            for (int i = 0; i < _rots.Length; i++)
                RotateOnUpdate((IRotator.AxisType)i, Time.deltaTime);
        }

        public void OnFixedUpdate()
        {
            for (int i = 0; i < _rots.Length; i++)
                RotateOnUpdate((IRotator.AxisType)i, Time.fixedDeltaTime);
        }



        public void AddAxisRotation(IRotator.AxisType axisType, float factor)
        {
            if (!IsActive) return;

            _rots[(int)axisType] += factor;
        }

        void RotateOnUpdate(IRotator.AxisType axisType, float deltaTime)
        {
            if (!IsActive) return;

            float factor = _rots[(int)axisType];
            _rots[(int)axisType] = 0.0f;
            if (Mathf.Abs(factor) < Util.EPSILON) return;

            _rotation = _transform.localRotation;
            _euler = _rotation.eulerAngles;
            switch (axisType)
            {
                case IRotator.AxisType.X:
                    _euler.x = _euler.x + factor * _model.RotSpeed * deltaTime;
                    if (_euler.x > 180) _euler.x -= 360;
                    _euler.x = _model.RotatorLimiter.GetClampedEulerAngle(IRotator.AxisType.X, _euler.x);
                    break;
                case IRotator.AxisType.Y:
                    _euler.y = _euler.y + factor * _model.RotSpeed * deltaTime;
                    if (_euler.y > 180) _euler.y -= 360;
                    _euler.y = _model.RotatorLimiter.GetClampedEulerAngle(IRotator.AxisType.Y, _euler.y);
                    break;
                case IRotator.AxisType.Z:
                    _euler.z = _euler.z + factor * _model.RotSpeed * deltaTime;
                    if (_euler.z > 180) _euler.z -= 360;
                    _euler.z = _model.RotatorLimiter.GetClampedEulerAngle(IRotator.AxisType.Z, _euler.z);
                    break;
            }          
            
            _rotation = Quaternion.Euler(_euler);
            _transform.localRotation = _rotation;

        }
    }
}

