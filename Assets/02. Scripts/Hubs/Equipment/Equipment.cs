using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Hubs.Equipments
{
    public abstract class Equipment<T> : ObjectHub, IEquipment, IModelDependent<T> where T : IEquipmentModel
    {
        public T Model { get; private set; }

        EquipType IEquipment.EquipType => Model.Config.EquipType;

        public void Equip(Transform parent)
        {
            transform.SetParent(parent, false);
        }

        public void Unequip()
        {
            DestroyOrReturnToPool();
        }

        public void SetModel(T model)
        {
            Model = model;
        }
    }

}
