using System.Collections;
using UnityEngine;

namespace GamePlay.Modules.AI
{

    public class PatrolBehaviour : BehaviourBase<IPatrolBehaviourConfig, IFollowableAI>
    {
        Coroutine _patrolCoroutine;

        public PatrolBehaviour(IPatrolBehaviourConfig config, IFollowableAI ai) : base(config, ai)
        {

        }

        public override void Enter()
        {
            _ai.Model.SetSpeedRaito(_config.SpeedRatio);

            if (_patrolCoroutine != null)
                _ai.CoroutineRunner.StopCoroutineRunner(_patrolCoroutine);

            _patrolCoroutine = _ai.CoroutineRunner.RunCoroutine(PatrolCo());
        }
        public override void Exit()
        {
            if (_patrolCoroutine != null)
            {
                _ai.CoroutineRunner.StopCoroutineRunner(_patrolCoroutine);
                _patrolCoroutine = null;
            }
            _ai.Unfollow();
                
        }

        IEnumerator PatrolCo()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(_config.MinSpan, _config.MaxSpan));
                SetPatrolPosition();
            }
        }

        void SetPatrolPosition()
        {
            Vector3 position = _ai.Transform.position;
            Vector3 disp = Random.onUnitSphere;
            disp.y = 0;
            disp.Normalize();
            disp *= Random.Range(_config.MinRadius, _config.MaxRadius);
            position += disp;
            _ai.FollowPosition(position);
        }


        public override void Clear()
        {
            base.Clear();

            if (_patrolCoroutine != null)
            {
                _ai.CoroutineRunner.StopCoroutineRunner(_patrolCoroutine);
                _patrolCoroutine = null;
            }
        }
    }
}

