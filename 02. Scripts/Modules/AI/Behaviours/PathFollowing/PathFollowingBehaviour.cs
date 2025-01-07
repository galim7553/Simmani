using System.Collections;
using UnityEngine;

namespace GamePlay.Modules.AI
{
    /// <summary>
    /// 경로 추적 행동을 구현한 클래스입니다.
    /// </summary>
    public class PathFollowingBehaviour : BehaviourBase<IPathFollowingBehaviourConfig, IPathFollowableAI>
    {


        int _curPathIndex;
        Coroutine _coroutine;

        int _pingPoingDirection = 1;

        float _distance = 0;

        public PathFollowingBehaviour(IPathFollowingBehaviourConfig config, IPathFollowableAI ai) : base(config, ai)
        {
        }

        public override void Enter()
        {
            _ai.Model.SetSpeedRaito(_config.SpeedRatio);
            if (_coroutine != null)
                _ai.CoroutineRunner.StopCoroutineRunner(_coroutine);
            _coroutine = _ai.CoroutineRunner.RunCoroutine(PathFollowingCo());
        }

        IEnumerator PathFollowingCo()
        {
            if (_ai.Paths.Count == 0)
                yield break;

            WaitForSeconds waitForSeconds = new WaitForSeconds(_ai.UpdateSpan);
            _curPathIndex = 0;
            _ai.FollowPosition(_ai.Paths[_curPathIndex].position);
            while (true)
            {
                yield return waitForSeconds;
                _distance = Vector3.Distance(_ai.Transform.position, _ai.Paths[_curPathIndex].position);
                if(_distance < _config.BrakingDistance)
                {
                    CalculatePathIndex();
                    _ai.FollowPosition(_ai.Paths[_curPathIndex].position);
                }
            }
        }

        void CalculatePathIndex()
        {
            switch (_config.Type)
            {
                case IPathFollowingBehaviourConfig.LoopType.FowardLoop:
                    _curPathIndex = (_curPathIndex + 1) % _ai.Paths.Count;
                    break;
                case IPathFollowingBehaviourConfig.LoopType.PingPongLoop:
                    _curPathIndex = _curPathIndex + _pingPoingDirection;
                    if(_curPathIndex >= _ai.Paths.Count || _curPathIndex < 0)
                    {
                        _pingPoingDirection *= -1;
                        _curPathIndex += _pingPoingDirection;
                    }
                    break;
            }
        }

        public override void Exit()
        {
            if(_coroutine != null)
            {
                _ai.CoroutineRunner.StopCoroutineRunner(_coroutine);
                _coroutine = null;
            }
            _ai.Unfollow();
        }

        public override void Clear()
        {
            base.Clear();

            Exit();
        }
    }

}

