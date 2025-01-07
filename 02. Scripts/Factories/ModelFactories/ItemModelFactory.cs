using System.Collections.Generic;
using GamePlay.Commands;
using GamePlay.Configs;
using GamePlay.Datas;
using GamePlay.Hubs.Equipments;
using UnityEngine;

namespace GamePlay.Factories
{
    /// <summary>
    /// ItemModel�� �����ϴ� ���丮 Ŭ����.
    /// �پ��� Ÿ���� ������ �� ���� ������ �����մϴ�.
    /// </summary>
    public class ItemModelFactory : ConfigMapBase<ItemConfig>, IModelFactory<IItemModel, ItemData>
    {
        IModelFactory<IEquipmentModel, ItemData> _equipmentModelFactory;
        ICommandFactory _commandFactory;

        /// <summary>
        /// ItemModelFactory�� ������.
        /// </summary>
        /// <param name="configs">ItemConfig ����Ʈ.</param>
        /// <param name="equipmentModelFactory">��� ���� �����ϴ� ���丮 ��ü.</param>
        /// <param name="commandFactory">������ ��� ������ ���� ��� ���丮.</param>
        public ItemModelFactory(IEnumerable<ItemConfig> configs,
            IModelFactory<IEquipmentModel, ItemData> equipmentModelFactory,
            ICommandFactory commandFactory) : base(configs)
        {
            _equipmentModelFactory = equipmentModelFactory;
            _commandFactory = commandFactory;
        }

        /// <summary>
        /// ItemData�� ������� IItemModel ��ü�� �����մϴ�.
        /// </summary>
        /// <param name="data">������ ������.</param>
        /// <returns>������ IItemModel ��ü.</returns>
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
                            Debug.LogError($"{data.Key} �������� Usage�� ã�� �� �����ϴ�.");
                            return new ItemModel(config, data);
                        }
                            
                }
            }

            LogMissingConfig(data.Key);
            return new ItemModel(new ItemConfig(), data);
        }
    }
}
