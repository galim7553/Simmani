using GamePlay.Hubs.Equipments;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Factories
{
    public class EquipmentFactory
    {
        PoolManager _poolManager;
        IDamageReceiverMappable _damageReceiverMappable;

        GearFactory _gearFactory;
        WeaponFactory _weaponFactory;


        public EquipmentFactory(PoolManager poolManager, IDamageReceiverMappable damageReceiverMappable, ILightController lightController)
        {
            _poolManager = poolManager;
            _damageReceiverMappable = damageReceiverMappable;

            _gearFactory = new GearFactory(_poolManager, lightController);
            _weaponFactory = new WeaponFactory(_poolManager, _damageReceiverMappable);
        }

        public Gear CreateGear(GearModel model)
        {                
            return _gearFactory.Create(model);
        }
        public Weapon CreateWeapon(WeaponModel model)
        {                
            return _weaponFactory.Create(model);
        }

        public IEquipment CreateEquipment(IEquipmentModel model)
        {
            switch (model)
            {
                case GearModel gearModel:
                    return CreateGear(gearModel);
                case WeaponModel weaponModel:
                    return CreateWeapon(weaponModel);
            }
            Debug.LogError($"장비의 타입이 맞지 않습니다. {model.Config.Key} : {model.Config.EquipType}");

            // 후에 기본값 처리
            return null;
        }
    }
}