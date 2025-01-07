using UnityEngine;

namespace GamePlay.Hubs.Equipments
{

    /// <summary>
    /// 장비의 기본 동작을 구현하는 추상 클래스.
    /// </summary>
    /// <typeparam name="T">장비 모델 타입</typeparam>
    public abstract class Equipment<T> : ObjectHub, IEquipment, IModelDependent<T> where T : IEquipmentModel
    {

        /// <summary>
        /// 장비 모델.
        /// </summary>
        public T Model { get; private set; }

        EquipType IEquipment.EquipType => Model.Config.EquipType;

        /// <summary>
        /// 장비를 부모 트랜스폼에 장착합니다.
        /// </summary>
        public void Equip(Transform parent)
        {
            transform.SetParent(parent, false);
        }

        /// <summary>
        /// 장비를 해제하고 제거합니다.
        /// </summary>
        public void Unequip()
        {
            DestroyOrReturnToPool();
        }

        /// <summary>
        /// 장비 모델을 설정합니다.
        /// </summary>
        public void SetModel(T model)
        {
            Model = model;
        }
    }

}
