using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// Transform을 기반으로 회전을 처리하는 클래스.
    /// </summary>
    public class TransformRotator : ModuleBase, IRotator, IUpdatable, IFixedUpdatable
    {
        IRotatorModel _model;
        Transform _transform;

        // 각 축의 회전 값을 저장하는 배열
        float[] _rots = new float[] { 0.0f, 0.0f, 0.0f };

        Quaternion _rotation; // 현재 회전값
        Vector3 _euler;       // Euler 각도로 표현된 회전값

        /// <summary>
        /// TransformRotator 생성자.
        /// </summary>
        /// <param name="model">회전 데이터를 관리하는 모델</param>
        /// <param name="transform">회전을 적용할 Transform</param>
        public TransformRotator(IRotatorModel model, Transform transform)
        {
            _model = model;
            _transform = transform;
        }

        /// <summary>
        /// Update 주기에서 각 축에 대한 회전 처리를 수행합니다.
        /// </summary>
        public void OnUpdate()
        {
            for (int i = 0; i < _rots.Length; i++)
                RotateOnUpdate((IRotator.AxisType)i, Time.deltaTime);
        }

        /// <summary>
        /// FixedUpdate 주기에서 각 축에 대한 회전 처리를 수행합니다.
        /// </summary>
        public void OnFixedUpdate()
        {
            for (int i = 0; i < _rots.Length; i++)
                RotateOnUpdate((IRotator.AxisType)i, Time.fixedDeltaTime);
        }

        /// <summary>
        /// 특정 축에 대해 회전값을 추가합니다.
        /// </summary>
        /// <param name="axisType">회전 축</param>
        /// <param name="factor">추가할 회전 값</param>
        public void AddAxisRotation(IRotator.AxisType axisType, float factor)
        {
            if (!IsActive) return;

            _rots[(int)axisType] += factor;
        }

        /// <summary>
        /// 지정된 축과 시간 동안 회전 처리를 수행합니다.
        /// </summary>
        /// <param name="axisType">회전 축</param>
        /// <param name="deltaTime">프레임 간 시간</param>
        void RotateOnUpdate(IRotator.AxisType axisType, float deltaTime)
        {
            if (!IsActive) return;

            float factor = _rots[(int)axisType];
            _rots[(int)axisType] = 0.0f; // 처리 후 값을 초기화
            if (Mathf.Abs(factor) < Util.EPSILON) return; // 미세한 값은 무시

            _rotation = _transform.localRotation;
            _euler = _rotation.eulerAngles;

            // 축별로 회전 처리
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
            _transform.localRotation = _rotation; // 로컬 회전 값 적용
        }
    }
}