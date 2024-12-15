using System.Collections;
using System.Collections.Generic;
using GamePlay.Datas;
using UnityEngine;

namespace GamePlay.Factories
{
    public class ConversationModelMap : IModelMap<IConversationModel>
    {
        IConversationConfig _config;
        IConversationMap _conversationMap;
        Dictionary<string, IConversationModel> _modelMap = new Dictionary<string, IConversationModel>();

        public ConversationModelMap(IConversationConfig config, IConversationMap conversationMap)
        { 
            _config = config;
            _conversationMap = conversationMap;
        }
        public IConversationModel GetModel(string key)
        {
            if(_modelMap.TryGetValue(key, out var model))
                return model;

            model = new ConversationModel(_config, _conversationMap.GetConversationText(key));
            _modelMap[key] = model;
            return model;
        }
    }
}


