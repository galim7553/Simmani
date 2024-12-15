using System.Collections;
using System.Collections.Generic;
using System.Data;
using GamePlay.Commands;
using GamePlay.Configs;
using GamePlay.Datas;
using GamePlay.Hubs.Equipments;
using UnityEngine;

namespace GamePlay.Factories
{
    public class ItemModelFactory : ConfigMapBase<ItemConfig>, IModelFactory<IItemModel, ItemData>
    {
        IModelFactory<IEquipmentModel, ItemData> _equipmentModelFactory;
        ICommandFactory _commandFactory;
        public ItemModelFactory(IEnumerable<ItemConfig> configs,
            IModelFactory<IEquipmentModel, ItemData> equipmentModelFactory,
            ICommandFactory commandFactory) : base(configs)
        {
            _equipmentModelFactory = equipmentModelFactory;
            _commandFactory = commandFactory;
        }

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
