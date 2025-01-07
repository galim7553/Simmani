using System.Collections;
using UnityEngine;

namespace GamePlay.Modules.AI
{

    /// <summary>
    /// AI�� ���� �ൿ�� ������ Ŭ�����Դϴ�.
    /// </summary>
    public class AttackingBehaviour : BehaviourBase<IAttackingBehaviourConfig, IAttackableAI>
    {
        Coroutine _attackingCoroutine;

        /// <summary>
        /// ���� �ൿ�� ������.
        /// </summary>
        /// <param name="config">���� �ൿ ������.</param>
        /// <param name="ai">���� ������ AI ��ü.</param>
        public AttackingBehaviour(IAttackingBehaviourConfig config, IAttackableAI ai) : base(config, ai)
        {
        }

        /// <summary>���� �ൿ ���� �� ȣ��˴ϴ�.</summary>
        public override void Enter()
        {
            if(_attackingCoroutine != null)
                _ai.CoroutineRunner.StopCoroutineRunner(_attackingCoroutine);
            _attackingCoroutine = _ai.CoroutineRunner.RunCoroutine(AttackingCo());
        }

        /// <summary>���� �ڷ�ƾ �����Դϴ�.</summary>
        IEnumerator AttackingCo()
        {
            float elapsedTime = _config.Span;

            while (true)
            {
                yield return null;
                elapsedTime += Time.deltaTime;


                if (_ai.IsPaused == true || _ai.Target == null)
                    continue;

                // Target ���� ���� ���
                Vector3 directionToTarget = (_ai.Target.position - _ai.Transform.position).normalized;
                directionToTarget.y = 0;

                Vector3 forwardDirection = _ai.Transform.forward;
                forwardDirection.y = 0;

                // AI�� Target�� ���鿡 �ΰ� �ִ��� Ȯ��
                float angleToTarget = Vector3.Angle(forwardDirection, directionToTarget);

                if (angleToTarget <= _config.AngleThreshold)
                {
                    // ���鿡 ���� �� ����

                    if (elapsedTime > _config.Span)
                    {
                        elapsedTime = 0.0f;
                        _ai.Attack();
                    }
                    _ai.InvokeRotatedEvent(0);
                }
                else
                {
                    // Target�� �ٶ󺸵��� ȸ��
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

        /// <summary>���� �ൿ ���� �� ȣ��˴ϴ�.</summary>
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