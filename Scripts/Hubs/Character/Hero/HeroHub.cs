using System;
using UnityEngine;
using GamePlay.Modules;
using GamePlay.Components;
using GamePlay.Hubs.Equipments;
using UnityEngine.UI;
using UnityEngine.AI;

namespace GamePlay.Hubs
{
    /// <summary>
    /// �÷��̾� ĳ����(Hero) ����� ����ϴ� Ŭ����.
    /// ��� ����� ���踦 ����ϸ�, ĳ������ �̵�, ����, �ǰ�, ���� ���� �ֿ� ����� ó��.
    /// </summary>
    public class HeroHub : ObjectHub, IUpdater, IFixedUpdater, IModelDependent<HeroModel>,
        IAttackable, IMovable, IJumpable, IProcessRunnable, ISprintable
    {

        /// <summary>HeroHub���� �ڽ� ������Ʈ�� ã�� ���� Ű��.</summary>
        enum ChildKey
        {
            CameraFocus,
            TargetBox,
            InteractorDetectorOrigin,
            InteractionBarBackground,
            InteractionBar,
        }

        /// <summary>
        /// HeroHub�� ���Ե� ������Ʈ���� ����.
        /// </summary>
        public class HeroComponents
        {
            public CharacterControllerPhysics CharacterControllerPhysics { get; private set; }
            public Transform InteractorDetectorOrigin {  get; private set; }
            public CharacterController CharacterController { get; private set; }
            public Collider TargetCollider { get; private set; }
            public CharacterAnimatorHandler CharacterAnimatorHandler { get; private set; }
            public Animator Animator { get; private set; }
            public NavMeshObstacle NavMeshObstacle { get; private set; }
            public GameObject InteractionBarBackground { get; private set; }
            public Image InteractionBar {  get; private set; }

            public HeroComponents(CharacterControllerPhysics characterControllerPhysics,
                Transform interactorDetectorOrigin,
                CharacterController characterController,
                Collider targetCollider,
                CharacterAnimatorHandler characterAnimatorHandler,
                Animator animator,
                NavMeshObstacle navMeshObstacle,
                GameObject interactionBarBackground,
                Image interactionBar)
            {
                CharacterControllerPhysics = characterControllerPhysics;
                InteractorDetectorOrigin = interactorDetectorOrigin;
                CharacterController = characterController;
                TargetCollider = targetCollider;
                CharacterAnimatorHandler = characterAnimatorHandler;
                Animator = animator;
                NavMeshObstacle = navMeshObstacle;
                InteractionBarBackground = interactionBarBackground;
                InteractionBar = interactionBar;
            }
        }
        public HeroModel Model { get; private set; }
        public HeroComponents Components { get; private set; }

        /// <summary>���� ����.</summary>
        public IJumper.JumpState JumpState => _jumper.State;

        /// <summary>���μ��� ���� ���� ����.</summary>
        public bool IsProcessRunnable => (_combatStater.State == ICombatStater.CombatState.Idle
            && _processRunner.IsRunning == false
            && _jumper.State == IJumper.JumpState.OnGround);

        public event Action OnUpdate;
        public event Action OnFixedUpdate;

        // ��� ���� ����
        IMover _mover;
        IJumper _jumper;
        IDamageReceiver _damageReceiver;
        IEquipper _equipper;
        ICombatStater _combatStater;
        IProcessRunner _processRunner;
        ISprinter _sprinter;

        /// <summary>HeroHub ������Ʈ �ʱ�ȭ.</summary>
        private void Awake()
        {

            Billboard hud = GetComponentInChildren<Billboard>();
            Components = new HeroComponents(GetComponent<CharacterControllerPhysics>(),
                transform.Find(ChildKey.InteractorDetectorOrigin.ToString()),
                GetComponent<CharacterController>(),
                gameObject.FindChild<Collider>(ChildKey.TargetBox.ToString()),
                GetComponentInChildren<CharacterAnimatorHandler>(),
                GetComponentInChildren<Animator>(),
                GetComponent<NavMeshObstacle>(),
                hud.gameObject.FindChild(ChildKey.InteractionBarBackground.ToString()),
                hud.gameObject.FindChild<Image>(ChildKey.InteractionBar.ToString(), true));

        }

        /// <summary>�� ����.</summary>
        public void SetModel(HeroModel model)
        {
            Model = model;
        }

        /// <summary>HeroHub �ʱ�ȭ �� ��� ����.</summary>
        public override void Initialize()
        {
            if(Modules.HasInitialized == false)
            {
                LogUninitializedModuleError();
                return;
            }

            // ��� ����
            _mover = Modules.Get<IMover>();
            _jumper = Modules.Get<IJumper>();
            _damageReceiver = Modules.Get<IDamageReceiver>();
            _equipper = Modules.Get<IEquipper>();
            _combatStater = Modules.Get<ICombatStater>();
            _processRunner = Modules.Get<IProcessRunner>();
            _sprinter = Modules.Get<ISprinter>();

            // ��� �̺�Ʈ ����
            _mover.OnDirectionChanged += OnDirectionChanged;
            _damageReceiver.OnDamaged += OnDamaged;

            _combatStater.AddExitAction(ICombatStater.CombatState.Attacking, OnCombatAttackingExited);

            _processRunner.OnBegan += OnProcessBegan;
            _processRunner.OnProcess += OnProcess;
            _processRunner.OnEnded += OnProcessEnded;

            Components.CharacterAnimatorHandler.OnSetWeaponColliderActive += SetWeaponColliderActive;

            _equipper.Initialize();
            _combatStater.SetState(ICombatStater.CombatState.Idle);
        }

        // ----- ��� �� �̺�Ʈ ó�� ���� ----- //
        void OnDirectionChanged(Vector3 moveVector) 
        {
            Components.CharacterAnimatorHandler.SetForwardSpeed(moveVector.z);
            Components.CharacterAnimatorHandler.SetRightSpeed(moveVector.x);
        }
        void OnDamaged(float damage)
        {
            // �ǰ� �ִϸ��̼� ���
            Components.CharacterAnimatorHandler.SetOnDamagedTrigger();

            // �ǰݵǾ� ���� ���·� ����
            _combatStater.SetState(ICombatStater.CombatState.Stiffened);

            // �ǰ� �� ���� ���� �ൿ�� �ִٸ� ���
            if (_processRunner.IsRunning == true)
                _processRunner.Fail();
        }


        void OnCombatAttackingExited()
        {
            SetWeaponColliderActive(false);
        }

        void OnProcessBegan()
        {
            _mover.SetDirection(0, 0, 0);
            Components.InteractionBar.fillAmount = 0;
        }
        void OnProcess(float rate)
        {
            Components.InteractionBarBackground.SetActive(true);
            Components.InteractionBar.fillAmount = rate;
        }
        void OnProcessEnded()
        {
            Components.InteractionBarBackground.SetActive(false);
            Components.CharacterAnimatorHandler.SetOnLooting(false);
        }
        // ----- ��� �� �̺�Ʈ ó�� ���� ----- //

        // ----- �÷��̾� ĳ���� �ൿ ----- //
        public void Move(Vector2 inputVector)
        {
            if (_processRunner.IsRunning == true) return;

            _mover.SetDirection(inputVector.x, 0.0f, inputVector.y);
        }
        public void Jump()
        {
            if (_processRunner.IsRunning == true) return;
            if(_mover.Speed < Util.EPSILON) return;

            _jumper.Jump();
        }
        public void Attack()
        {
            if (_processRunner.IsRunning == true) return;

            IWeapon weapon = _equipper.Cache.Weapon;
            if (weapon != null
                && _combatStater.State == ICombatStater.CombatState.Idle)
            {
                // ���� �ִϸ��̼� ���
                Components.CharacterAnimatorHandler.SetOnAttackTrigger();

                // ���� ���·� ����
                _combatStater.SetState(ICombatStater.CombatState.Attacking);
            }
        }

        public void BeginProcess(IProcessable processable)
        {
            if (IsProcessRunnable == false) return;

            switch (processable.Type)
            {
                case IProcessable.ProcessType.Loot:
                    Components.CharacterAnimatorHandler.SetOnLooting(true);
                    break;
            }
            _processRunner.Begin(processable);
        }
        public void BeginProcessWithExternalControl(IProcessable processable, out Action onEnded)
        {
            if (IsProcessRunnable == false)
            {
                onEnded = null;
                return;
            }

            _processRunner.BeginWithExternalControl(processable);
            onEnded = () => { _processRunner.End(); };
        }

        public void SetIsSprinting(bool isSprinting)
        {
            _sprinter.SetIsSprinting(isSprinting);
        }


        void SetWeaponColliderActive(bool isActive)
        {
            IWeapon weapon = _equipper.Cache.Weapon;
            if (weapon != null)
            {
                if(isActive == false)
                    weapon.SetColliderActive(isActive);

                // Ȱ��ȭ�� �� ���� ������ ���� Ȱ��ȭ
                else
                {
                    if(_combatStater.State == ICombatStater.CombatState.Attacking)
                        weapon.SetColliderActive(isActive);
                }
            }
        }
        // ----- �÷��̾� ĳ���� �ൿ ----- //


        private void Update()
        {
            OnUpdate?.Invoke();
        }
        private void FixedUpdate()
        {
            OnFixedUpdate?.Invoke();
        }
        public void AddUpdatable(IUpdatable updatable)
        {
            OnUpdate += updatable.OnUpdate;
        }

        public void AddFixedUpdatable(IFixedUpdatable fixedUpdatable)
        {
            OnFixedUpdate += fixedUpdatable.OnFixedUpdate;
        }

        public override void Clear()
        {
            base.Clear();

            Components.CharacterAnimatorHandler.Clear();

            OnUpdate = null;
            OnFixedUpdate = null;

            _mover = null;
            _jumper = null;
            _damageReceiver = null;
            _equipper = null;
            _combatStater = null;
            _processRunner = null;
            _sprinter = null;
        }
    }
}