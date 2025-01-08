using System;
using System.Collections;
using GamePlay.Hubs;
using UnityEngine;
using UnityEngine.AI;

namespace GamePlay.Modules
{
    /// <summary>
    /// NavMeshAgent�� ������� �� ���� ��� ����.
    /// </summary>
    public class NavMeshAgentFollwer : ModuleBase, IFollower, IUpdatable, IFixedUpdatable
    {
        IFollowerModel _model;
        NavMeshAgent _agent;
        Transform _transform;
        ICoroutineRunner _coroutineRunner;

        Coroutine _followingCoroutine;


        Vector3 _preVelocity; // ���� �������� �ӵ�.
        Vector3 _velocity;    // ���� �������� �ӵ�.


        /// <summary>�ӵ� ���� �̺�Ʈ.</summary>
        public event Action<Vector3> OnVelocityChanged;

        /// <summary>
        /// ������: NavMeshAgent�� ����ϴ� ���� ��� �ʱ�ȭ.
        /// </summary>
        public NavMeshAgentFollwer(IFollowerModel model, NavMeshAgent agent, ICoroutineRunner coroutineRunner)
        {
            _model = model;
            _agent = agent;
            _transform = agent.transform;
            _coroutineRunner = coroutineRunner;
        }

        /// <summary>
        /// ��� Transform�� ���󰡴� �ڷ�ƾ.
        /// </summary>
        IEnumerator FollowCo(Transform target)
        {
            float elapsedTime = 0.0f;

            while (true)
            {
                elapsedTime += Time.deltaTime;
                if(elapsedTime > _model.Config.UpdateSpan && _agent.isStopped == false)
                {
                    elapsedTime = 0.0f;
                    _agent.speed = _model.Speed;
                    _agent.angularSpeed = _model.AngularSpeed;
                    _agent.SetDestination(target.position);
                }
                yield return null;
            }
        }

        public void SetTarget(Transform target)
        {

            if(_followingCoroutine != null)
                _coroutineRunner.StopCoroutineRunner(_followingCoroutine);

            _followingCoroutine = _coroutineRunner.RunCoroutine(FollowCo(target));
        }

        public void SetTarget(Vector3 position)
        {
            if (_followingCoroutine != null)
            {
                _coroutineRunner.StopCoroutineRunner(_followingCoroutine);
                _followingCoroutine = null;
            }
                

            _agent.speed = _model.Speed;
            _agent.angularSpeed = _model.AngularSpeed;
            _agent.SetDestination(position);
        }
        public void Stop()
        {
            if (_followingCoroutine != null)
            {
                _coroutineRunner.StopCoroutineRunner(_followingCoroutine);
                _followingCoroutine = null;
            }
            _agent.velocity = Vector3.zero;
            _agent.ResetPath();
        }

        public void Pause(bool isPause)
        {
            _agent.isStopped = isPause;
            if (_agent.isStopped == true)
                _agent.velocity = Vector3.zero;
        }

        public void OnUpdate()
        {
            FollowOnUpdate(Time.deltaTime);
        }

        public void OnFixedUpdate()
        {
            FollowOnUpdate(Time.fixedDeltaTime);
        }

        /// <summary>
        /// �ӵ� ������ ������Ʈ�ϰ� ���� ������ ��ε�ĳ��Ʈ.
        /// </summary>
        void FollowOnUpdate(float deltaTime)
        {
            _velocity = _transform.InverseTransformDirection(_agent.velocity);
            if (_velocity.magnitude < Util.EPSILON)
                _velocity = Vector3.zero;

            if (Mathf.Abs(_velocity.x - _preVelocity.x) < Util.EPSILON
                && Mathf.Abs(_velocity.y - _preVelocity.y) < Util.EPSILON
                && Mathf.Abs(_velocity.z - _preVelocity.z) < Util.EPSILON)
                return;

            _preVelocity = _velocity;
            OnVelocityChanged?.Invoke(_velocity);
        }

        public override void Clear()
        {
            base.Clear();

            OnVelocityChanged = null;
            Stop();
            _agent.velocity = Vector3.zero;
            _agent.ResetPath();
        }
    }

}
