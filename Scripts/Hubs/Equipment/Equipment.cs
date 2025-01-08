using UnityEngine;

namespace GamePlay.Hubs.Equipments
{

    /// <summary>
    /// ����� �⺻ ������ �����ϴ� �߻� Ŭ����.
    /// </summary>
    /// <typeparam name="T">��� �� Ÿ��</typeparam>
    public abstract class Equipment<T> : ObjectHub, IEquipment, IModelDependent<T> where T : IEquipmentModel
    {

        /// <summary>
        /// ��� ��.
        /// </summary>
        public T Model { get; private set; }

        EquipType IEquipment.EquipType => Model.Config.EquipType;

        /// <summary>
        /// ��� �θ� Ʈ�������� �����մϴ�.
        /// </summary>
        public void Equip(Transform parent)
        {
            transform.SetParent(parent, false);
        }

        /// <summary>
        /// ��� �����ϰ� �����մϴ�.
        /// </summary>
        public void Unequip()
        {
            DestroyOrReturnToPool();
        }

        /// <summary>
        /// ��� ���� �����մϴ�.
        /// </summary>
        public void SetModel(T model)
        {
            Model = model;
        }
    }

}
