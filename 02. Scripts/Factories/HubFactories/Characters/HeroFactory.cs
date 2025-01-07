using GamePlay.Hubs;
using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Factories
{
    /// <summary>
    /// HeroHub �ν��Ͻ��� �����ϰ� �ʱ�ȭ�ϴ� ���丮 Ŭ����.
    /// </summary>
    public class HeroFactory : FactoryBase<HeroHub, HeroModel>
    {
        IDamageReceiverMappable _damageReceiverMappable;
        EquipmentFactory _equipmentFactory;

        /// <summary>
        /// HeroFactory ������.
        /// </summary>
        /// <param name="poolManager">������Ʈ Ǯ���� �����ϴ� PoolManager.</param>
        /// <param name="equipmentFactory">��� �����ϴ� EquipmentFactory.</param>
        /// <param name="damageReceiverMappable">�ǰ� ������ �����ϴ� DamageReceiverMappable.</param>
        public HeroFactory(PoolManager poolManager, EquipmentFactory equipmentFactory, IDamageReceiverMappable damageReceiverMappable) : base(poolManager)
        {
            _equipmentFactory = equipmentFactory;
            _damageReceiverMappable = damageReceiverMappable;
        }


        /// <summary>
        /// HeroHub�� ���� �� �ʱ�ȭ.
        /// </summary>
        /// <param name="model">HeroHub�� ������ ��.</param>
        /// <returns>�ʱ�ȭ�� HeroHub �ν��Ͻ�.</returns>
        public override HeroHub Create(HeroModel model)
        {
            // HeroHub ���� �Ǵ� Ǯ���� ��������
            HeroHub heroHub = _poolManager.GetFromPool(model.PrefabPath).GetOrAddComponent<HeroHub>();

            // �� ����
            heroHub.SetModel(model);

            // ��� ����
            ModuleContainer modules = heroHub.Modules;

            // �̵� ��� ����
            CharacterControllerPhysicsMover mover = new CharacterControllerPhysicsMover(model.SprintableMoverModel, heroHub.Components.CharacterControllerPhysics, Space.Self);
            SprintableMover sprintableMover = new SprintableMover(model.SprintableMoverModel, mover);
            modules.Set<IMover>(sprintableMover);
            modules.Set<ISprinter>(sprintableMover);

            // ���� ��� ����
            CharacterControllerPhysicsJumper jumper = new CharacterControllerPhysicsJumper(model.Config, heroHub.Components.CharacterControllerPhysics);
            modules.Set<IJumper>(jumper);

            // �ǰ� ��� ����
            modules.Set<IDamageReceiver>(new DamageReceiver(model.DamageReceiverModel, heroHub.transform, heroHub.Components.TargetCollider, _damageReceiverMappable));

            // ��� ���� ��� ����
            modules.Set<IEquipper>(new Equipper(model.EquipperModel, _equipmentFactory, heroHub.Components.Animator));

            // ���� ���� ��� ����
            CombatStater combatStater = new CombatStater(model.Config);
            modules.Set<ICombatStater>(combatStater);

            // ���μ��� ���� ��� ����
            modules.Set<IProcessRunner>(new ProcessRunner(heroHub));

            // �Ƿε� ��� ����
            FatigueController fatigueController = new FatigueController(model.FatigueModel);
            modules.Set<IFatigueController>(fatigueController);

            // FixedUpdate �� Update �̺�Ʈ�� �ʿ��� ��� ���
            heroHub.AddFixedUpdatable(mover);
            heroHub.AddFixedUpdatable(jumper);
            heroHub.AddUpdatable(combatStater);
            heroHub.AddUpdatable(fatigueController);
            heroHub.AddUpdatable(sprintableMover);

            // ��� ��� �ʱ�ȭ
            modules.Initialize();
            heroHub.Initialize();

            return heroHub;
        }
    }


}