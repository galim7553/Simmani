using System.Collections.Generic;
using GamePlay.Commands;
using GamePlay.Configs;
using GamePlay.Datas;
using GamePlay.Hubs.Equipments;
using UnityEngine;

namespace GamePlay.Factories
{
    /// <summary>
    /// ItemModel을 생성하는 팩토리 클래스.
    /// 다양한 타입의 아이템 모델 생성 로직을 포함합니다.
    /// </summary>
    public class ItemModelFactory : ConfigMapBase<ItemConfig>, IModelFactory<IItemModel, ItemData>
    {
        IModelFactory<IEquipmentModel, ItemData> _equipmentModelFactory;
        ICommandFactory _commandFactory;

        /// <summary>
        /// ItemModelFactory의 생성자.
        /// </summary>
        /// <param name="configs">ItemConfig 리스트.</param>
        /// <param name="equipmentModelFactory">장비 모델을 생성하는 팩토리 객체.</param>
        /// <param name="commandFactory">아이템 사용 로직을 위한 명령 팩토리.</param>
        public ItemModelFactory(IEnumerable<ItemConfig> configs,
            IModelFactory<IEquipmentModel, ItemData> equipmentModelFactory,
            ICommandFactory commandFactory) : base(configs)
        {
            _equipmentModelFactory = equipmentModelFactory;
            _commandFactory = commandFactory;
        }

        /// <summary>
        /// ItemData를 기반으로 IItemModel 객체를 생성합니다.
        /// </summary>
        /// <param name="data">아이템 데이터.</param>
        /// <returns>생성된 IItemModel 객체.</returns>
        public IItemModel CreateModel(ItemData data)
        {
            if(_configMap.TryGetValue(data.Key, out var config))
            {
                switch (config.ItemType)
                {
                    case ItemType.Sansam:
                    case ItemType.Sellable:
                        return new ItemModel(config, data);
                    case ItemType.Equipment:
                        return new ItemModel(config, data, _equipmentModelFactory.CreateModel(data));
                    case ItemType.Consumable:
                    case ItemType.Passive:
                        ICommand command = _commandFactory.CreateCommand(config.UsageKey);
                        if (command is IItemUsage itemUsage)
                            return new ItemModel(config, data, itemUsage);
                        else
                        {
                            Debug.LogError($"{data.Key} 아이템의 Usage를 찾을 수 없습니다.");
                            return new ItemModel(config, data);
                        }
                            
                }
            }

            LogMissingConfig(data.Key);
            return new ItemModel(new ItemConfig(), data);
        }
    }
}
