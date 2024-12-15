using GamePlay.Hubs;
using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Factories
{
    public class HeroFactory : FactoryBase<HeroHub, HeroModel>
    {
        IDamageReceiverMappable _damageReceiverMappable;
        EquipmentFactory _equipmentFactory;

        public HeroFactory(PoolManager poolManager, EquipmentFactory equipmentFactory, IDamageReceiverMappable damageReceiverMappable) : base(poolManager)
        {
            _equipmentFactory = equipmentFactory;
            _damageReceiverMappable = damageReceiverMappable;
        }



        public override HeroHub Create(HeroModel model)
        {
            HeroHub heroHub = _poolManager.GetFromPool(model.PrefabPath).GetOrAddComponent<HeroHub>();

            // 모델 설정
            heroHub.SetModel(model);

            // 모듈 설정
            ModuleContainer modules = heroHub.Modules;

            CharacterControllerPhysicsMover mover = new CharacterControllerPhysicsMover(model.SprintableMoverModel, heroHub.Components.CharacterControllerPhysics, Space.Self);
            SprintableMover sprintableMover = new SprintableMover(model.SprintableMoverModel, mover);
            modules.Set<IMover>(sprintableMover);
            modules.Set<ISprinter>(sprintableMover);

            CharacterControllerPhysicsJumper jumper = new CharacterControllerPhysicsJumper(model.Config, heroHub.Components.CharacterControllerPhysics);
            modules.Set<IJumper>(jumper);

            modules.Set<IDamageReceiver>(new DamageReceiver(model.DamageReceiverModel, heroHub.transform, heroHub.Components.TargetCollider, _damageReceiverMappable));
            modules.Set<IEquipper>(new Equipper(model.EquipperModel, _equipmentFactory, heroHub.Components.Animator));

            CombatStater combatStater = new CombatStater(model.Config);
            modules.Set<ICombatStater>(combatStater);
            modules.Set<IProcessRunner>(new ProcessRunner(heroHub));

            FatigueController fatigueController = new FatigueController(model.FatigueModel);
            modules.Set<IFatigueController>(fatigueController);

            heroHub.AddFixedUpdatable(mover);
            heroHub.AddFixedUpdatable(jumper);
            heroHub.AddUpdatable(combatStater);
            heroHub.AddUpdatable(fatigueController);
            heroHub.AddUpdatable(sprintableMover);

            modules.Initialize();
            heroHub.Initialize();

            return heroHub;
        }
    }


}