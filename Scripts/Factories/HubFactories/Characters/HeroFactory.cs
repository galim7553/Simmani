using GamePlay.Hubs;
using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Factories
{
    /// <summary>
    /// HeroHub 인스턴스를 생성하고 초기화하는 팩토리 클래스.
    /// </summary>
    public class HeroFactory : FactoryBase<HeroHub, HeroModel>
    {
        IDamageReceiverMappable _damageReceiverMappable;
        EquipmentFactory _equipmentFactory;

        /// <summary>
        /// HeroFactory 생성자.
        /// </summary>
        /// <param name="poolManager">오브젝트 풀링을 관리하는 PoolManager.</param>
        /// <param name="equipmentFactory">장비를 생성하는 EquipmentFactory.</param>
        /// <param name="damageReceiverMappable">피격 정보를 관리하는 DamageReceiverMappable.</param>
        public HeroFactory(PoolManager poolManager, EquipmentFactory equipmentFactory, IDamageReceiverMappable damageReceiverMappable) : base(poolManager)
        {
            _equipmentFactory = equipmentFactory;
            _damageReceiverMappable = damageReceiverMappable;
        }


        /// <summary>
        /// HeroHub를 생성 및 초기화.
        /// </summary>
        /// <param name="model">HeroHub에 설정할 모델.</param>
        /// <returns>초기화된 HeroHub 인스턴스.</returns>
        public override HeroHub Create(HeroModel model)
        {
            // HeroHub 생성 또는 풀에서 가져오기
            HeroHub heroHub = _poolManager.GetFromPool(model.PrefabPath).GetOrAddComponent<HeroHub>();

            // 모델 설정
            heroHub.SetModel(model);

            // 모듈 설정
            ModuleContainer modules = heroHub.Modules;

            // 이동 모듈 설정
            CharacterControllerPhysicsMover mover = new CharacterControllerPhysicsMover(model.SprintableMoverModel, heroHub.Components.CharacterControllerPhysics, Space.Self);
            SprintableMover sprintableMover = new SprintableMover(model.SprintableMoverModel, mover);
            modules.Set<IMover>(sprintableMover);
            modules.Set<ISprinter>(sprintableMover);

            // 점프 모듈 설정
            CharacterControllerPhysicsJumper jumper = new CharacterControllerPhysicsJumper(model.Config, heroHub.Components.CharacterControllerPhysics);
            modules.Set<IJumper>(jumper);

            // 피격 모듈 설정
            modules.Set<IDamageReceiver>(new DamageReceiver(model.DamageReceiverModel, heroHub.transform, heroHub.Components.TargetCollider, _damageReceiverMappable));

            // 장비 장착 모듈 설정
            modules.Set<IEquipper>(new Equipper(model.EquipperModel, _equipmentFactory, heroHub.Components.Animator));

            // 전투 상태 모듈 설정
            CombatStater combatStater = new CombatStater(model.Config);
            modules.Set<ICombatStater>(combatStater);

            // 프로세스 실행 모듈 설정
            modules.Set<IProcessRunner>(new ProcessRunner(heroHub));

            // 피로도 모듈 설정
            FatigueController fatigueController = new FatigueController(model.FatigueModel);
            modules.Set<IFatigueController>(fatigueController);

            // FixedUpdate 및 Update 이벤트에 필요한 모듈 등록
            heroHub.AddFixedUpdatable(mover);
            heroHub.AddFixedUpdatable(jumper);
            heroHub.AddUpdatable(combatStater);
            heroHub.AddUpdatable(fatigueController);
            heroHub.AddUpdatable(sprintableMover);

            // 모든 모듈 초기화
            modules.Initialize();
            heroHub.Initialize();

            return heroHub;
        }
    }


}