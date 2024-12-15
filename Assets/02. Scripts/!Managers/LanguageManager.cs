using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStringMap
{
    string GetString(string key);
}
public interface IConversationMap
{
    string GetConversationText(string key);
}

public enum LanguageType
{
    Korean,
    English
}

[Serializable]
public class LanguageContainer
{
    [SerializeField] LanguageNode[] _nodes;
    public IReadOnlyList<LanguageNode> Nodes => _nodes;
}

[Serializable]
public class ConversationContainer
{
    [SerializeField] ConversationNode[] _nodes;
    public IReadOnlyList<ConversationNode> Nodes => _nodes;
}

[Serializable]
public class LanguageNode
{
    [SerializeField] string _key;
    [SerializeField] string _value;

    public string Key => _key;
    public string Value => _value;
}

[Serializable]
public class ConversationNode
{
    [SerializeField] string _key;
    [SerializeField] string _text;

    public string Key => _key;
    public string Text => _text;
}

public class LanguageManager : IStringMap, IConversationMap
{
    IResourceMap _resourceMap;
    Dictionary<string, LanguageNode> _stringMap = new Dictionary<string, LanguageNode>();
    Dictionary<string, ConversationNode> _conversationMap = new Dictionary<string, ConversationNode>();



    public LanguageManager(IResourceMap resourceMap)
    {
        _resourceMap = resourceMap;

        TextAsset langTextAsset = _resourceMap.LoadResource<TextAsset>("Languages/Korean");
        LanguageContainer languageContainer = JsonUtility.FromJson<LanguageContainer>(langTextAsset.text);
        foreach (var node in languageContainer.Nodes)
            _stringMap[node.Key] = node;

        TextAsset conversationTextAsset = _resourceMap.LoadResource<TextAsset>("Languages/Conversation_Korean");
        ConversationContainer conversationContainer = JsonUtility.FromJson<ConversationContainer>(conversationTextAsset.text);
        foreach (var node in conversationContainer.Nodes)
            _conversationMap[node.Key] = node;
    }

    public string GetString(string key)
    {
        if (_stringMap.TryGetValue(key, out var node))
            return node.Value;

        Debug.LogWarning($"{key} 문자열이 존재하지 않습니다.");
        return string.Empty;
    }
    public string GetConversationText(string key)
    {
        if(_conversationMap.TryGetValue(key, out var conversation))
            return conversation.Text;

        Debug.LogWarning($"{key} Conversation이 존재하지 않습니다.");
        return string.Empty;
    }
}
