using GamePlay.Hubs.Equipments;
using GamePlay.Modules;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Factories
{
    public class WeaponFactory : FactoryBase<Weapon, WeaponModel>
    {
        IDamageReceiverMappable _damageReceiverMappable;
        public WeaponFactory(PoolManager poolManager, IDamageReceiverMappable damageReceiverMappable) : base(poolManager)
        {
            _damageReceiverMappable = damageReceiverMappable;
        }

        public override Weapon Create(WeaponModel model)
        {
            Weapon weapon = _poolManager.GetFromPool(model.PrefabPath).GetOrAddComponent<Weapon>();

            // �� ����
            weapon.SetModel(model);

            // ��� ����
            weapon.Modules.Set<IDamageSender>(new DamageSender(model.DamageSenderModel, _damageReceiverMappable));

            weapon.Modules.Initialize();
            weapon.Initialize();
            return weapon;
        }
    }
}