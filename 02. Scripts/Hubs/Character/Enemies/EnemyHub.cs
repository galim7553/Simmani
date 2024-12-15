using System;
using System.Collections;
using GamePlay.Components;
using GamePlay.Modules;
using GamePlay.Modules.AI;
using UnityEngine;
using UnityEngine.AI;

namespace GamePlay.Hubs
{
    public class EnemyHub : ObjectHub, IUpdater, IFixedUpdater, IModelDependent<EnemyModel>, IAttackable
    {
        enum ChildKey
        {
            TargetBox,
            Weapon,
            HitSphereCenter,
        }

        public class EnemyComponents
        {
            public Renderer[] Renderers {  get; private set; }
            public NavMeshAgent NavMeshAgent { get; private set; }
            public Collider Collider { get; private set; }
            public Collider TargetCollider { get; private set; }
            public Collider WeaponCollider { get; private set; }
            public CharacterAnimatorHandler CharacterAnimatorHandler { get; private set; }
            public Animator Animator { get; private set; }
            public TriggerHandler WeaponTriggerHandler { get; private set; }
            public Transform HitSphereCenter { get; private set; }

            public EnemyComponents(Renderer[] renderers, NavMeshAgent navMeshAgent, Collider collider, Collider targetCollider,
                Collider weaponCollider, CharacterAnimatorHandler characterAnimatorHandler, Animator animator,
                TriggerHandler weaponTriggerHandler, Transform hitSphereCenter)
            {
                Renderers = renderers;
                NavMeshAgent = navMeshAgent;
                Collider = collider;
                TargetCollider = targetCollider;
                WeaponCollider = weaponCollider;
                CharacterAnimatorHandler = characterAnimatorHandler;
                Animator = animator;
                WeaponTriggerHandler = weaponTriggerHandler;
                HitSphereCenter = hitSphereCenter;
            }
        }

        public EnemyModel Model { get; private set; }
        public EnemyComponents Components { get; private set; }

        public event Action OnUpdate;
        public event Action OnFixedUpdate;

        IEnemyMap _enemyMap;

        protected IFollower _follower;
        protected ICombatStater _combatStater;
        protected IEnemyAI _enemyAI;

        Rigidbody _rigidbody;

        private void Awake()
        {
            Components = new EnemyComponents(
                GetComponentsInChildren<SkinnedMeshRenderer>(true),
                GetComponent<NavMeshAgent>(),
                GetComponentInChildren<Collider>(),
                gameObject.FindChild<Collider>(ChildKey.TargetBox.ToString()),
                gameObject.FindChild<Collider>(ChildKey.Weapon.ToString(), true),
                GetComponentInChildren<CharacterAnimatorHandler>(),
                GetComponentInChildren<Animator>(),
                GetComponentInChildren<TriggerHandler>(),
                gameObject.FindChild<Transform>(ChildKey.HitSphereCenter.ToString(), true));

            _rigidbody = GetComponent<Rigidbody>();
        }
        public void SetModel(EnemyModel model)
        {
            Model = model;
        }

        private void OnEnable()
        {
            SetWeaponColliderActive(false);
            Components.Collider.enabled = true;
            Components.NavMeshAgent.enabled = true;
        }
        public override void Initialize()
        {
            if (Modules.HasInitialized == false)
            {
                LogUninitializedModuleError();
                return;
            }

            _follower = Modules.Get<IFollower>();
            _combatStater = Modules.Get<ICombatStater>();
            _enemyAI = Modules.Get<IEnemyAI>();
            IDamageReceiver damageReceiver = Modules.Get<IDamageReceiver>();

            _follower.OnVelocityChanged += OnVelocityChanged;

            _enemyAI.OnRotated += OnRotated;

            damageReceiver.OnDamaged += OnDamaged;
            damageReceiver.OnDead += OnDead;

            _combatStater.AddEnterAction(ICombatStater.CombatState.Stiffened, OnCombatStiffenedEntered);
            _combatStater.AddExitAction(ICombatStater.CombatState.Stiffened, OnCombatStiffenedExited);
            _combatStater.AddExitAction(ICombatStater.CombatState.Attacking, OnCombatAttackingExited);

            Components.CharacterAnimatorHandler.OnSetWeaponColliderActive += SetWeaponColliderActive;
            Components.WeaponTriggerHandler.OnTriggerEntered += OnWeaponTriggerEntered;

            _enemyAI.Start();
        }

        public void SetEnemyMap(IEnemyMap enemyMap)
        {
            _enemyMap = enemyMap;
        }

        public void Attack()
        {
            Components.CharacterAnimatorHandler.SetOnAttackTrigger();

            _combatStater.SetState(ICombatStater.CombatState.Attacking);
        }



        void OnCombatStiffenedEntered()
        {
            _follower.Pause(true);
            _enemyAI.Pause(true);
        }
        void OnCombatStiffenedExited()
        {
            _follower.Pause(false);
            _enemyAI.Pause(false);
        }

        void OnCombatAttackingExited()
        {
            SetWeaponColliderActive(false);
        }

        void OnVelocityChanged(Vector3 velocity)
        {
            Components.CharacterAnimatorHandler.SetForwardSpeed(velocity.magnitude);
        }
        void OnRotated(float speed)
        {
            Components.CharacterAnimatorHandler.SetForwardSpeed(speed);
        }
        void OnDamaged(float damage)
        {
            Components.CharacterAnimatorHandler.SetOnDamagedTrigger();

            _combatStater.SetState(ICombatStater.CombatState.Stiffened);
        }

        void OnDead()
        {
            SetWeaponColliderActive(false);
            Components.CharacterAnimatorHandler.SetOnDeadTrigger();
            Components.Collider.enabled = false;

            Clear();

            StartCoroutine(DieCo());
        }

        IEnumerator DieCo()
        {
            yield return new WaitForSeconds(Model.Config.CorpseDuration);
            DestroyOrReturnToPool();
        }


        void SetWeaponColliderActive(bool isActive)
        {
            if(isActive == false)
                Components.WeaponCollider.enabled = isActive;
            else
            {
                if (_combatStater.State == ICombatStater.CombatState.Attacking)
                    Components.WeaponCollider.enabled = isActive;
            }
        }

        void OnWeaponTriggerEntered(Collider collider)
        {
            IDamageSender damageSender = Modules.Get<IDamageSender>();

            if (damageSender != null)
                Modules.Get<IDamageSender>().OnHit(collider);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Hero")
                _rigidbody.isKinematic = true;
        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "Hero")
                _rigidbody.isKinematic = false;
        }

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

        void OnDrawGizmosSelected()
        {
            if (_enemyAI == null || _combatStater == null) return;

            Gizmos.color = Color.yellow; // �⺻ Gizmo ���� ����
            Vector3 position = transform.position + Vector3.up * 2;

            // Gizmo�� �ؽ�Ʈ �׸���
            DrawTextInScene(position, $"AI ����: {_enemyAI.State}, ���� ����: {_combatStater.State}", Color.yellow, 30);
        }

        void DrawTextInScene(Vector3 position, string text, Color color, int fontSize)
        {
#if UNITY_EDITOR
            // GUI ��Ÿ�� ����
            GUIStyle style = new GUIStyle();
            style.normal.textColor = color;
            style.fontSize = fontSize;
            style.alignment = TextAnchor.MiddleCenter; // �ؽ�Ʈ ����

            // UnityEditor Handles�� ���ڿ� �׸���
            UnityEditor.Handles.Label(position, text, style);
#endif
        }

        // Test
        void OnGUI()
        {
            if (_enemyAI == null || _combatStater == null) return;

            float dist = Vector3.Distance(Camera.main.transform.position, transform.position);
            if (dist > 50.0f) return;

            // ���� ��ǥ�� ��ũ�� ��ǥ�� ��ȯ
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2);

            // ����� ī�޶� �տ� ���� ���� ǥ��
            if (screenPos.z > 0)
            {
                // Unity�� ��ũ�� ��ǥ�� ���� �Ʒ��� (0, 0)�̰� GUI ��ǥ�� ���� ���� (0, 0)�̹Ƿ� Y�� ���� �ʿ�
                Vector3 guiPosition = screenPos + Vector3.up * 50;
                guiPosition.y = Screen.height - guiPosition.y;

                // GUI ��Ÿ�� ����
                GUIStyle style = new GUIStyle();
                style.normal.textColor = Color.yellow;
                style.fontSize = 30;
                style.alignment = TextAnchor.MiddleCenter;

                // �ؽ�Ʈ �׸���
                GUI.Label(new Rect(guiPosition.x - 100, guiPosition.y - 50, 200, 100), $"AI ����: {_enemyAI.State}, ���� ����: {_combatStater.State}", style);
            }
        }

        public override void Clear()
        {
            base.Clear();

            Components.CharacterAnimatorHandler.Clear();
            Components.WeaponTriggerHandler.Clear();
            Components.NavMeshAgent.enabled = false;

            OnUpdate = null;
            OnFixedUpdate = null;

            _follower = null;
            _enemyAI = null;
            _combatStater = null;

            if(_enemyMap != null)
                _enemyMap.RemoveEnemy(Model.Id);
            _enemyMap = null;

            StopAllCoroutines();
        }
    }
}


