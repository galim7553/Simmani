using System.Collections;
using UnityEngine;

namespace GamePlay.Modules.AI
{

    /// <summary>
    /// AI의 공격 행동을 구현한 클래스입니다.
    /// </summary>
    public class AttackingBehaviour : BehaviourBase<IAttackingBehaviourConfig, IAttackableAI>
    {
        Coroutine _attackingCoroutine;

        /// <summary>
        /// 공격 행동의 생성자.
        /// </summary>
        /// <param name="config">공격 행동 설정값.</param>
        /// <param name="ai">공격 가능한 AI 객체.</param>
        public AttackingBehaviour(IAttackingBehaviourConfig config, IAttackableAI ai) : base(config, ai)
        {
        }

        /// <summary>공격 행동 시작 시 호출됩니다.</summary>
        public override void Enter()
        {
            if(_attackingCoroutine != null)
                _ai.CoroutineRunner.StopCoroutineRunner(_attackingCoroutine);
            _attackingCoroutine = _ai.CoroutineRunner.RunCoroutine(AttackingCo());
        }

        /// <summary>공격 코루틴 로직입니다.</summary>
        IEnumerator AttackingCo()
        {
            float elapsedTime = _config.Span;

            while (true)
            {
                yield return null;
                elapsedTime += Time.deltaTime;


                if (_ai.IsPaused == true || _ai.Target == null)
                    continue;

                // Target 방향 벡터 계산
                Vector3 directionToTarget = (_ai.Target.position - _ai.Transform.position).normalized;
                directionToTarget.y = 0;

                Vector3 forwardDirection = _ai.Transform.forward;
                forwardDirection.y = 0;

                // AI가 Target을 정면에 두고 있는지 확인
                float angleToTarget = Vector3.Angle(forwardDirection, directionToTarget);

                if (angleToTarget <= _config.AngleThreshold)
                {
                    // 정면에 있을 때 공격

                    if (elapsedTime > _config.Span)
                    {
                        elapsedTime = 0.0f;
                        _ai.Attack();
                    }
                    _ai.InvokeRotatedEvent(0);
                }
                else
                {
                    // Target을 바라보도록 회전
                    Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                    _ai.Transform.rotation = Quaternion.Slerp(
                        _ai.Transform.rotation,
                        targetRotation,
                        _config.RotSpeed * Time.deltaTime
                    );
                    _ai.InvokeRotatedEvent(1.0f);
                }
            }
        }

        /// <summary>공격 행동 종료 시 호출됩니다.</summary>
        public override void Exit()
        {
            if(_attackingCoroutine != null)
            {
                _ai.CoroutineRunner.StopCoroutineRunner(_attackingCoroutine);
                _attackingCoroutine = null;
            }
        }


        public override void Clear()
        {
            base.Clear();

            Exit();
        }
    }

}