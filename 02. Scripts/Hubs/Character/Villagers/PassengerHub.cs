using System;
using GamePlay.Components;
using GamePlay.Modules;
using GamePlay.Modules.AI;
using UnityEngine;
using UnityEngine.AI;

namespace GamePlay.Hubs
{
    public class PassengerHub : ObjectHub, IUpdater
    {
        public class PassengerComponents
        {
            public Collider Collider { get; private set; }
            public NavMeshAgent NavMeshAgent { get; private set; }
            public CharacterAnimatorHandler CharacterAnimatorHandler { get; private set; }
            public PassengerComponents(Collider collider, NavMeshAgent navMeshAgent, CharacterAnimatorHandler characterAnimatorHandler)
            {
                Collider = collider;
                NavMeshAgent = navMeshAgent;
                CharacterAnimatorHandler = characterAnimatorHandler;
            }
        }

        public PassengerModel Model { get; private set; }
        public PassengerComponents Components { get; private set; }
        Rigidbody _rigidbody;

        public event Action OnUpdate;

        IFollower _follower;

        private void Awake()
        {
            Components = new PassengerComponents(
                GetComponent<Collider>(),
                GetComponent<NavMeshAgent>(),
                GetComponentInChildren<CharacterAnimatorHandler>());

            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            _rigidbody.isKinematic = true;
        }

        private void Update()
        {
            OnUpdate?.Invoke();
        }

        public void SetModel(PassengerModel model)
        {
            Model = model;
        }

        public override void Initialize()
        {
            if (Modules.HasInitialized == false)
            {
                LogUninitializedModuleError();
                return;
            }

            IPassengerAI passengerAI = Modules.Get<IPassengerAI>();
            passengerAI.Start();

            _follower = Modules.Get<IFollower>();
            _follower.OnVelocityChanged += OnVelocityChanged;

            IInteractor interactor = Modules.Get<IInteractor>();
            interactor.OnInteractionBegan += OnInteractionBegan;
            interactor.OnInteractionEnded += OnInteractionEnded;
        }

        void OnVelocityChanged(Vector3 velocity)
        {
            Components.CharacterAnimatorHandler.SetForwardSpeed(velocity.magnitude);
        }

        void OnInteractionBegan()
        {
            _follower.Pause(true);
        }
        void OnInteractionEnded()
        {
            _follower.Pause(false);
        }

        public void AddUpdatable(IUpdatable updatable)
        {
            OnUpdate += updatable.OnUpdate;
        }

        public override void Clear()
        {
            base.Clear();

            _follower = null;
        }
    }

}

