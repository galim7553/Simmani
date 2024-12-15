using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay.Modules.AI
{
    public class EnemyAI : ModuleBase, IEnemyAI
    {
        IEnemyAIModel _model;
        IFollower _follower;
        IAttackable _attackable;
        ITargetFinder _targetFinder;

        public EnemyAIState State { get; private set; }
        public float UpdateSpan => _model.Config.UpdateSpan;
        public Vector3 SpawnPosition { get; private set; }
        IFollowableAIModel IFollowableAI.Model => _model;

        public Transform Transform { get; private set; }
        public ICoroutineRunner CoroutineRunner { get; private set; }

        IBehaviour[] _behaviours;
        IBehaviour _curBehaviour;
        public bool IsPaused { get; private set; } = false;
        IDamageReceiver _target;
        public Transform Target => _target.Transform;
        public string Key => _model.Config.Key;

        Coroutine _checkStateCoroutine;

        public event Action<float> OnRotated;
        public event Action OnTargetChanged;

        public EnemyAI(IEnemyAIModel model, Transform transform, ICoroutineRunner coroutineRunner,
            IFollower follower, IAttackable attackable, ITargetFinder targetFinder, Vector3 spawnPosition)
        {
            _model = model;
            Transform = transform;
            CoroutineRunner = coroutineRunner;
            _follower = follower;
            _attackable = attackable;
            _targetFinder = targetFinder;

            SpawnPosition = spawnPosition;
        }

        public void Initialize(IBehaviour[] behaviours)
        {
            _behaviours = behaviours;
        }

        public void Start()
        {
            if(_checkStateCoroutine != null)
                CoroutineRunner.StopCoroutineRunner(_checkStateCoroutine);
            SetState(EnemyAIState.Idle);
            _checkStateCoroutine = CoroutineRunner.RunCoroutine(CheckStateCo());
        }
        public void Stop()
        {
            if(_checkStateCoroutine != null)
            {
                CoroutineRunner.StopCoroutineRunner(_checkStateCoroutine);
                _checkStateCoroutine = null;
            }
        }

        IEnumerator CheckStateCo()
        {
            float elapsedTime = 0.0f;

            while (true)
            {
                yield return null;
                elapsedTime += Time.deltaTime;
                if(elapsedTime > _model.Config.UpdateSpan)
                {
                    elapsedTime = 0.0f;
                    CheckState();
                }
                    
            }
        }

        void OnTargetDead()
        {
            if (_target != null)
                _target.OnDead -= OnTargetDead;

            _target = null;
            CheckState();
        }
        public void CheckState()
        {
            // 새 타겟 찾기 시도
            IDamageReceiver newTarget = _targetFinder.FindTarget(_model.Config.DetectionLength);

            // 새 타겟이 있으면 타겟 교체
            if (newTarget != null)
            {
                if (_target != newTarget)
                {
                    if(_target != null)
                        _target.OnDead -= OnTargetDead;
                    _target = newTarget;
                    _target.OnDead += OnTargetDead;
                    OnTargetChanged?.Invoke();
                }
            }
                

            // 타겟이 있는 경우
            if (_target != null)
            {
                // 타겟과의 거리 계산
                float distanceToTarget = Vector3.Distance(Transform.position, Target.position);

                if(distanceToTarget < _model.Config.AttackLength ||
                    _targetFinder.GetIsInHitSphere(_target, _model.Config.HitSphereRadius))
                {
                    // 타겟이 AttackLength 이거나 공격 가능 범위 안에 있으면 Attacking 상태
                    ChangeState(EnemyAIState.Attacking);
                }
                else if(distanceToTarget < _model.Config.TraceLength)
                {
                    // 타겟이 TraceLength 이내이고 AttackLength보다 멀면 Trace 상태
                    ChangeState(EnemyAIState.Tracing);
                }
                else
                {
                    // 타겟이 TraceLength보다 멀면 Idle 상태로 전환
                    ChangeState(EnemyAIState.Idle);
                    _target.OnDead -= OnTargetDead;
                    _target = null; // 타겟을 잃어버림
                }
            }
            else
            {
                // 타겟이 여전히 없으면 Idle 상태를 유지
                ChangeState(EnemyAIState.Idle);
            }
        }

        void ChangeState(EnemyAIState state)
        {
            if (_curBehaviour == _behaviours[(int)state]) return;

            SetState(state);
        }
        void SetState(EnemyAIState state)
        {
            State = state;
            if (_curBehaviour != null)
                _curBehaviour.Exit();

            _curBehaviour = _behaviours[(int)state];
            _curBehaviour.Enter();
        }

        public void Pause(bool isPause)
        {
            IsPaused = isPause;
        }



        public void FollowTarget(Transform target)
        {
            if (target == null) return;

            _follower.SetTarget(target);
        }
        public void FollowPosition(Vector3 position)
        {
            _follower.SetTarget(position);
        }
        public void Unfollow()
        {
            _follower.Stop();
        }
        public void Attack()
        {
            _attackable.Attack();
        }
        public void InvokeRotatedEvent(float speed)
        {
            OnRotated?.Invoke(speed);
        }


        public override void Clear()
        {
            base.Clear();

            if (_target != null)
                _target.OnDead -= OnTargetDead;

            _target = null;
            Stop();
            OnRotated = null;
            OnTargetChanged = null;
            foreach(var behaviour in _behaviours)
                behaviour.Clear();
        }
    }

}

