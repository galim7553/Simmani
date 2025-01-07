using System.Collections.Generic;
using GamePlay.Hubs;

namespace GamePlay.Modules
{
    /// <summary>
    /// Å¸°Ù Å½Áö ¸ðµ¨ ±¸Çö.
    /// </summary>
    public class TargetFinderModel : ModuleModelBase<ITargetFinderConfig>, ITargetFinderModel
    {
        Dictionary<CharacterTagType, int> _tagPriorityMap = new Dictionary<CharacterTagType, int>();

        /// <summary>
        /// Å¸°Ù Å½Áö ¸ðµ¨ »ý¼ºÀÚ.
        /// </summary>
        /// <param name="config">Å¸°Ù Å½Áö ¼³Á¤.</param>
        public TargetFinderModel(ITargetFinderConfig config) : base(config)
        {

            MapTagPriority();
        }

        /// <summary>
        /// ÅÂ±× ¿ì¼±¼øÀ§¸¦ ¼³Á¤.
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