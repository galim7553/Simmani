using System.Collections;
using System.Collections.Generic;
using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Hubs.Equipments
{
    public class Weapon : Equipment<WeaponModel>, IWeapon
    {

        public class WeaponComponents
        {
            public Collider Collider { get; private set; }
            public WeaponComponents(Collider collider)
            {
                Collider = collider;
            }
        }
        public WeaponComponents Components { get; private set; }

        IDamageSender _damageSender;

        void Awake()
        {
            Components = new WeaponComponents(GetComponent<Collider>());
        }
        public override void Initialize()
        {
            if(Modules.HasInitialized == false)
            {
                LogUninitializedModuleError();
                return;
            }

            _damageSender = Modules.Get<IDamageSender>();
        }


        public void SetColliderActive(bool isActive)
        {
            Components.Collider.enabled = isActive;
        }

        private void OnEnable() 
        {
            SetColliderActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            _damageSender.OnHit(other);
        }

        public override void Clear()
        {
            base.Clear();

            _damageSender = null;
        }
    }
}


