using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using GamePlay.Components;
using GamePlay.Datas;
using GamePlay.Factories;
using GamePlay.Hubs;
using GamePlay.Modules;
using GamePlay.Presenters;
using GamePlay.Views;
using UnityEngine;
using UnityEngine.Rendering;

namespace GamePlay.Scene
{
    public class PlayScene : MonoBehaviour, IDamageReceiverMappable, IInteractorMappable, IUpdater, IFixedUpdater, ICoroutineRunner
    {
        Dictionary<Collider, IDamageReceiver> _damageReceiverMap = new Dictionary<Collider, IDamageReceiver>();
        Dictionary<Collider, IInteractor> _interactorMap = new Dictionary<Collider, IInteractor>();

        // ----- Factories ----- //
        HeroFactory _heroFactory;
        EquipmentFactory _equipmentFactory;
        // ----- Factories ----- //

        // ----- Models ----- //
        HeroModel _heroModel;
        IInventoryModel _inventoryModel;
        // ----- Models ----- //

        // ----- Camera ----- //
        [Header("----- Camera -----")]
        [SerializeField] CinemachineVirtualCamera _camera;
        [SerializeField] TargetFollower _cameraFocus;
        // ----- Camera ----- //

        // ----- Hubs ----- //
        [Header("----- Hero -----")]
        [SerializeField] Transform _heroSpwanPoint;
        protected HeroHub _heroHub;
        // ----- Hubs ----- //

        // ----- Sun ----- //
        [Header("----- Sun -----")]
        [SerializeField] Light _light;
        [SerializeField] Volume _volume;
        // ----- Sun ----- //

        // ----- Components ----- //
        InputHandler _inputHandler;
        // ----- Components ----- //

        // ----- Modules ----- //
        InventoryController _inventoryController;
        InteractionController _interactionController;
        SunController _sunController;
        StatusController _statusController;
        DamagedEffectPresenter _damagedEffectPresenter;
        ConversationController _conversationController;
        TransformRotator _cameraFocusRotator;
        // ----- Modules ----- //

        // ----- Views ----- //
        [Header("----- View -----")]
        [SerializeField] InventoryMenuView _inventoryMenuView;
        [SerializeField] StageView _stageView;
        [SerializeField] TimeCycleView _timeCycleView;
        [SerializeField] HeroStatView _heroStatView;
        [SerializeField] HotKeyGroupView _hotKeyGroupView;
        [SerializeField] DamagedEffectView _damagedEffectView;
        [SerializeField] ConversationView _conversationView;
        // ----- Views ----- //

        // ----- UI ----- //
        [Header("----- UI -----")]
        [SerializeField] Transform _interactionMark;
        // ----- UI ----- //

        public event Action OnUpdate;
        public event Action OnFixedUpdate;

        protected virtual void Awake()
        {
            _inputHandler = GetComponent<InputHandler>();

            InitializeSunController();
            _equipmentFactory = new EquipmentFactory(GameManager.Inst.PoolManager, this, _sunController);
            _heroFactory = new HeroFactory(GameManager.Inst.PoolManager, _equipmentFactory, this);

            _heroModel = GameManager.Inst.ModelManager.WorldModel.HeroModel;
            _inventoryModel = GameManager.Inst.ModelManager.WorldModel.InventoryModel;
        }

        protected virtual void Start()
        {
            // ----- Cursor ----- //
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            // ----- Cursor ----- //

            BuildHero();
            SubscribeInputEvents();

            InitializeConversationController();
            InitializeInventoryMenuController();
            InitializeInteractionController();
            InitializeStatusController();
            InitializeDamagedEffectPresenter();


        }
        void BuildHero()
        {
            _heroHub = _heroFactory.Create(_heroModel);
            _heroHub.transform.SetParent(transform, false);
            _heroHub.Components.CharacterControllerPhysics.SetPosition(_heroSpwanPoint.position);
            _heroHub.transform.rotation = _heroSpwanPoint.rotation;

            _cameraFocus.transform.rotation = _heroHub.transform.rotation;
            _camera.Follow = _cameraFocus.transform;
            _camera.LookAt = _cameraFocus.transform;
            _cameraFocus.SetTarget(_heroHub.transform);
            _camera.transform.position = _cameraFocus.transform.position + Vector3.back * 10;

            _cameraFocusRotator = new TransformRotator(GameManager.Inst.ConfigManager.GamePlayConfig, _cameraFocus.transform);
            AddFixedUpdatable(_cameraFocusRotator);

            _heroHub.Modules.Get<IDamageReceiver>().OnDamaged += OnHeroDamaged;
        }
        void SubscribeInputEvents()
        {
            _inputHandler.OnMove += OnMoveInput;
            _inputHandler.OnMouseMove += OnMouseMoveInput;
            _inputHandler.OnJump += OnJumpInput;
            _inputHandler.OnLeftClick += OnLeftClickInput;
            _inputHandler.OnSprint += OnSprintInput;
            _inputHandler.OnHotKeyDown += OnHotKeyInput;
            _inputHandler.OnInteraction += OnInteractionInput;
            _inputHandler.OnInventoryMenu += OnInventoryMenuInput;
            _inputHandler.OnEscape += OnEscapeInput;
        }

        void InitializeConversationController()
        {
            _conversationController = new ConversationController(GameManager.Inst.ModelManager.WorldModel.ConversationModelMap, _conversationView);
        }
        void InitializeInteractionController()
        {
            InteractorDetector interactorDetector = new InteractorDetector(
                GameManager.Inst.ModelManager.WorldModel.InteractorDectectorModel,
                _heroHub.Components.InteractorDetectorOrigin,
                this);
            AddUpdatable(interactorDetector);

            InteractionPlayer interactionPlayer = new InteractionPlayer(
                _heroHub,
                _conversationController,
                _inventoryController);

            _interactionController = new InteractionController(interactorDetector, interactionPlayer, _interactionMark);
        }
        void InitializeInventoryMenuController()
        {
            _inventoryController = new InventoryController(
                GameManager.Inst.ModelManager.WorldModel.InventoryModel,
                _heroModel,
                _inventoryMenuView, GameManager.Inst.PoolManager.ViewFactory);
        }
        void InitializeSunController()
        {
            _sunController = new SunController(GameManager.Inst.ModelManager.WorldModel.TimeCycleModel, _light, _volume);
            OnUpdate += _sunController.OnUpdate;
        }
        void InitializeStatusController()
        {
            _statusController = new StatusController(
                GameManager.Inst.ModelManager.WorldModel.StageModel,
                GameManager.Inst.ModelManager.WorldModel.TimeCycleModel,
                _heroModel,
                _inventoryModel,
                GameManager.Inst.ConfigManager.HotKeyGroupConfig,
                _stageView, _timeCycleView, _heroStatView, _hotKeyGroupView);
        }
        void InitializeDamagedEffectPresenter()
        {
            _damagedEffectPresenter = new DamagedEffectPresenter(
                GameManager.Inst.ConfigManager.DamagedEffectConfig,
                _damagedEffectView);
        }

        protected virtual void Update()
        {
            OnUpdate?.Invoke();


            // Temp
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Clear();
                GameManager.Inst.SceneLoader.LoadScene(SceneLoader.SceneKey.Menu);
            }
        }

        void FixedUpdate()
        {
            OnFixedUpdate?.Invoke();
        }

        void OnMoveInput(Vector2 inputVector)
        {
            if (_inventoryController.IsActive == true) return;

            if (inputVector.magnitude > Util.EPSILON)
            {
                Vector3 euler = _heroHub.transform.eulerAngles;
                euler.y = _cameraFocus.transform.eulerAngles.y;
                _heroHub.transform.eulerAngles = euler;
            }
            _heroHub.Move(inputVector);
        }
        void OnMouseMoveInput(Vector2 inputVector)
        {
            if (_inventoryController.IsActive == true) return;

            _cameraFocusRotator.AddAxisRotation(IRotator.AxisType.X, -inputVector.y);
            _cameraFocusRotator.AddAxisRotation(IRotator.AxisType.Y, inputVector.x);
        }
        void OnJumpInput()
        {
            if (_inventoryController.IsActive == true) return;
            _heroHub.Jump();
        }
        void OnLeftClickInput()
        {
            if (_inventoryController.IsActive == true) return;
            _heroHub.Attack();
        }
        void OnSprintInput(bool isOn)
        {
            if (_inventoryController.IsActive == true) return;
                _heroHub.SetIsSprinting(isOn);
        }
        void OnHotKeyInput(int index)
        {
            _statusController.ExecuteHotKey(index);
        }
        void OnInteractionInput()
        {
            if(_conversationController.IsPlaying == true)
                _conversationController.ExecuteNext();
            else
            {
                if(_inventoryController.IsActive == false)
                    _interactionController.ExecuteInteraction();
            }
                
        }
        void OnInventoryMenuInput()
        {
            if(_heroHub.JumpState == IJumper.JumpState.OnGround && _conversationController.IsPlaying == false)
            {
                OnMoveInput(Vector2.zero);
                _inventoryController.ToggleInventory();
            }
        }
        void OnEscapeInput()
        {
            if (_inventoryController.IsActive == true)
                _inventoryController.ToggleInventory();
        }

        void OnHeroDamaged(float damage)
        {
            _damagedEffectPresenter.OnHeroDamaged();
        }
        

        // ----- DamageReceiverMappable ----- //
        public void AddDamageReceiver(IDamageReceiver damageReceiver)
        {
            _damageReceiverMap[damageReceiver.Collider] = damageReceiver;
        }
        public void RemoveDamageReceiver(IDamageReceiver damageReceiver)
        {
            _damageReceiverMap.Remove(damageReceiver.Collider);
        }
        public bool TryGetDamageReceiver(Collider collider, out IDamageReceiver damageReceiver)
        {
            return _damageReceiverMap.TryGetValue(collider, out damageReceiver);
        }
        // ----- DamageReceiverMappable ----- //


        // ----- InteractorMappable ----- //
        public void AddInteractor(IInteractor interactor)
        {
            _interactorMap[interactor.Collider] = interactor;
        }

        public void RemoveInteractor(IInteractor interactor)
        {
            _interactorMap.Remove(interactor.Collider);
        }

        public bool TryGetInteractor(Collider collider, out IInteractor interactor)
        {
            return _interactorMap.TryGetValue(collider, out interactor);
        }
        // ----- InteractorMappable ----- //

        // ----- Updater ----- //
        public void AddUpdatable(IUpdatable updatable)
        {
            OnUpdate += updatable.OnUpdate;
        }
        public void AddFixedUpdatable(IFixedUpdatable fixedUpdatable)
        {
            OnFixedUpdate += fixedUpdatable.OnFixedUpdate;
        }
        // ----- Updater ----- //

        // ----- CorountineRunner ----- //
        public Coroutine RunCoroutine(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }

        public Coroutine RunCoroutine(IEnumerator coroutine, Action callback)
        {
            return StartCoroutine(RunCoroutineWithCallbackCo(coroutine, callback));
        }

        public void StopCoroutineRunner(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }
        IEnumerator RunCoroutineWithCallbackCo(IEnumerator coroutine, Action callback)
        {
            yield return coroutine;
            callback?.Invoke();
        }
        // ----- CorountineRunner ----- //

        public virtual void Clear()
        {
            OnUpdate = null;
            _inputHandler.Clear();
            _inventoryController.Clear();
            _interactionController.Clear();
            _sunController.Clear();
            _statusController.Clear();
            _damagedEffectPresenter.Clear();
            _cameraFocusRotator.Clear();

            _damageReceiverMap.Clear();
            _interactorMap.Clear();

            _heroHub.DestroyOrReturnToPool();
        }
    }
}


