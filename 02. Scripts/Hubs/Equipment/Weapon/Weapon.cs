using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Hubs.Equipments
{
    /// <summary>
    /// 무기(Weapon) 클래스. 무기의 동작을 정의.
    /// </summary>
    public class Weapon : Equipment<WeaponModel>, IWeapon
    {
        /// <summary>
        /// 무기의 구성 요소를 관리하는 클래스.
        /// </summary>
        public class WeaponComponents
        {
            public Collider Collider { get; private set; }
            public WeaponComponents(Collider collider)
            {
                Collider = collider;
            }
        }


        /// <summary>
        /// 무기의 구성 요소 인스턴스.
        /// </summary>
        public WeaponComponents Components { get; private set; }

        IDamageSender _damageSender;

        void Awake()
        {
            Components = new WeaponComponents(GetComponent<Collider>());
        }

        /// <summary>
        /// 무기 초기화. DamageSender 모듈 초기화 확인.
        /// </summary>
        public override void Initialize()
        {
            if(Modules.HasInitialized == false)
            {
                LogUninitializedModuleError();
                return;
            }

            _damageSender = Modules.Get<IDamageSender>();
        }

        /// <summary>
        /// 무기의 충돌체 활성화/비활성화 설정.
        /// </summary>
        public void SetColliderActive(bool isActive)
        {
            Components.Collider.enabled = isActive;
        }

        private void OnEnable() 
        {
            SetColliderActive(false); // 무기 활성화 시 충돌체 비활성화
        }

        private void OnTriggerEnter(Collider other)
        {
            _damageSender.OnHit(other); // 충돌 시 DamageSender 모듈에 처리 위임
        }

        public override void Clear()
        {
            base.Clear();

            _damageSender = null;
        }
    }
}


