using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Hubs.Equipments
{
    /// <summary>
    /// ����(Weapon) Ŭ����. ������ ������ ����.
    /// </summary>
    public class Weapon : Equipment<WeaponModel>, IWeapon
    {
        /// <summary>
        /// ������ ���� ��Ҹ� �����ϴ� Ŭ����.
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
        /// ������ ���� ��� �ν��Ͻ�.
        /// </summary>
        public WeaponComponents Components { get; private set; }

        IDamageSender _damageSender;

        void Awake()
        {
            Components = new WeaponComponents(GetComponent<Collider>());
        }

        /// <summary>
        /// ���� �ʱ�ȭ. DamageSender ��� �ʱ�ȭ Ȯ��.
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
        /// ������ �浹ü Ȱ��ȭ/��Ȱ��ȭ ����.
        /// </summary>
        public void SetColliderActive(bool isActive)
        {
            Components.Collider.enabled = isActive;
        }

        private void OnEnable() 
        {
            SetColliderActive(false); // ���� Ȱ��ȭ �� �浹ü ��Ȱ��ȭ
        }

        private void OnTriggerEnter(Collider other)
        {
            _damageSender.OnHit(other); // �浹 �� DamageSender ��⿡ ó�� ����
        }

        public override void Clear()
        {
            base.Clear();

            _damageSender = null;
        }
    }
}


