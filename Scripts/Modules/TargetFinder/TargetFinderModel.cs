using System.Collections.Generic;
using GamePlay.Hubs;

namespace GamePlay.Modules
{
    /// <summary>
    /// Ÿ�� Ž�� �� ����.
    /// </summary>
    public class TargetFinderModel : ModuleModelBase<ITargetFinderConfig>, ITargetFinderModel
    {
        Dictionary<CharacterTagType, int> _tagPriorityMap = new Dictionary<CharacterTagType, int>();

        /// <summary>
        /// Ÿ�� Ž�� �� ������.
        /// </summary>
        /// <param name="config">Ÿ�� Ž�� ����.</param>
        public TargetFinderModel(ITargetFinderConfig config) : base(config)
        {

            MapTagPriority();
        }

        /// <summary>
        /// �±� �켱������ ����.
        /// </summary>
        void MapTagPriority()
        {
            for (int i = 0; i < Config.TargetTags.Count; i++)
                _tagPriorityMap[Config.TargetTags[i]] = i;
                
        }

        public int GetTagPriority(CharacterTagType tagType)
        {
            if(_tagPriorityMap.TryGetValue(tagType, out int priority))
                return priority;
            return int.MaxValue;
        }

        public bool GetIsTargetTag(CharacterTagType tagType)
        {
            return _tagPriorityMap.ContainsKey(tagType);
        }
    }
}