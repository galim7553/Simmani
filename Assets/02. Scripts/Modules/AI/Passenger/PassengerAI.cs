using System.Collections;
using System.Collections.Generic;
using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay.Modules.AI
{
    public class PassengerAI : ModuleBase, IPassengerAI
    {
        IPassengerAIModel _model;
        IFollower _follower;

        public float UpdateSpan => _model.Config.UpdateSpan;
        public IFollowableAIModel Model => _model;
        public IReadOnlyList<Transform> Paths { get; private set; }       
        public Vector3 SpawnPosition { get; private set; }
        public string Key => _model.Config.Key;
        public Transform Transform { get; private set; }
        public ICoroutineRunner CoroutineRunner { get; private set; }


        IBehaviour _behaviour;

        public PassengerAI(IPassengerAIModel model, Transform transform, ICoroutineRunner coroutineRunner,
            IFollower follower, Transform[] paths)
        {
            _model = model;
            Transform = transform;
            CoroutineRunner = coroutineRunner;
            _follower = follower;
            Paths = paths;
            if(Paths.Count > 0)
                SpawnPosition = Paths[0].position;
        }

        public void Initialize(IBehaviour behaviour)
        {
            _behaviour = behaviour;
        }

        public void FollowPosition(Vector3 position)
        {
            _follower.SetTarget(position);
        }

        public void FollowTarget(Transform target)
        {
            if (target == null) return;

            _follower.SetTarget(target);
        }

        public void Pause(bool isPause)
        {
            
        }

        public void Start()
        {
            _behaviour.Enter();
        }

        public void Stop()
        {
            _behaviour.Exit();
        }

        public void Unfollow()
        {
            _follower.Stop();
        }
    }
}