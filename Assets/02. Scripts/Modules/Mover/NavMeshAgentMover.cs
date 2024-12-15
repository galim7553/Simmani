using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GamePlay.Modules
{
    public class NavMeshAgentMover : MoverBase, IFixedUpdatable, IUpdatable
    {
        NavMeshAgent _agent;
        Transform _transform;
        Space _space;

        Vector3 _step = Vector3.zero;
        Vector3 _targetPosition = Vector3.zero;
        NavMeshHit _hit;

        public NavMeshAgentMover(IMoverModel model, NavMeshAgent agent, Space space) : base(model)
        {
            _agent = agent;
            _transform = _agent.transform;
            _space = space;

            _agent.updateRotation = false;
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


            // 이번 스텝 위치가 NavMesh의 Walkable과 겹칠 때만 해당 위치로 이동
            _step = _space == Space.World ? _velocity * deltaTime :
                _transform.TransformDirection(_velocity) * deltaTime;
            _targetPosition = _transform.position + _step;
            if (NavMesh.SamplePosition(_targetPosition, out _hit, _step.magnitude, NavMesh.AllAreas))
                _agent.Move(_hit.position - _transform.position);
        }
    }
}

