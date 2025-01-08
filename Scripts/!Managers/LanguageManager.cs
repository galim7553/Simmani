using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 문자열 맵핑 인터페이스.
/// 키를 사용하여 문자열을 가져오는 기능을 제공합니다.
/// </summary>
public interface IStringMap
{
    /// <summary>
    /// 키를 사용하여 문자열을 반환합니다.
    /// </summary>
    /// <param name="key">문자열 키</param>
    /// <returns>매핑된 문자열</returns>
    string GetString(string key);
}

/// <summary>
/// 대화 텍스트 맵핑 인터페이스.
/// 키를 사용하여 대화 텍스트를 가져오는 기능을 제공합니다.
/// </summary>
public interface IConversationMap
{
    /// <summary>
    /// 키를 사용하여 대화 텍스트를 반환합니다.
    /// </summary>
    /// <param name="key">대화 키</param>
    /// <returns>매핑된 대화 텍스트</returns>
    string GetConversationText(string key);
}

/// <summary>
/// 지원 언어 타입.
/// </summary>
public enum LanguageType
{
    Korean,
    English
}

/// <summary>
/// 언어 데이터를 담는 컨테이너 클래스.
/// </summary>
[Serializable]
public class LanguageContainer
{
    [SerializeField] LanguageNode[] _nodes; // 언어 데이터 노드 배열

    /// <summary>
    /// 읽기 전용 언어 데이터 노드 리스트.
    /// </summary>
    public IReadOnlyList<LanguageNode> Nodes => _nodes;
}

/// <summary>
/// 대화 데이터를 담는 컨테이너 클래스.
/// </summary>
[Serializable]
public class ConversationContainer
{
    [SerializeField] ConversationNode[] _nodes; // 대화 데이터 노드 배열

    /// <summary>
    /// 읽기 전용 대화 데이터 노드 리스트.
    /// </summary>
    public IReadOnlyList<ConversationNode> Nodes => _nodes;
}

/// <summary>
/// 언어 데이터의 키-값 쌍을 나타내는 클래스.
/// </summary>
[Serializable]
public class LanguageNode
{
    [SerializeField] string _key; // 언어 키
    [SerializeField] string _value; // 언어 값

    /// <summary>
    /// 언어 데이터 키.
    /// </summary>
    public string Key => _key;

    /// <summary>
    /// 언어 데이터 값.
    /// </summary>
    public string Value => _value;
}

/// <summary>
/// 대화 데이터의 키-텍스트 쌍을 나타내는 클래스.
/// </summary>
[Serializable]
public class ConversationNode
{
    [SerializeField] string _key; // 대화 키
    [SerializeField] string _text; // 대화 텍스트

    /// <summary>
    /// 대화 데이터 키.
    /// </summary>
    public string Key => _key;

    /// <summary>
    /// 대화 데이터 텍스트.
    /// </summary>
    public string Text => _text;
}

/// <summary>
/// 언어 및 대화 데이터를 관리하는 클래스.
/// 리소스 맵을 사용하여 데이터를 로드하고 키를 통해 데이터를 검색합니다.
/// </summary>
public class LanguageManager : IStringMap, IConversationMap
{
    IResourceMap _resourceMap; // 리소스 관리 인터페이스
    Dictionary<string, LanguageNode> _stringMap = new Dictionary<string, LanguageNode>(); // 언어 데이터 맵
    Dictionary<string, ConversationNode> _conversationMap = new Dictionary<string, ConversationNode>(); // 대화 데이터 맵

    /// <summary>
    /// LanguageManager 생성자.
    /// 리소스 맵에서 데이터를 로드하고 초기화합니다.
    /// </summary>
    /// <param name="resourceMap">리소스 관리 인터페이스</param>
    public LanguageManager(IResourceMap resourceMap)
    {
        _resourceMap = resourceMap;

        // 언어 데이터 로드 및 맵 초기화
        TextAsset langTextAsset = _resourceMap.LoadResource<TextAsset>("Languages/Korean");
        LanguageContainer languageContainer = JsonUtility.FromJson<LanguageContainer>(langTextAsset.text);
        foreach (var node in languageContainer.Nodes)
            _stringMap[node.Key] = node;

        // 대화 데이터 로드 및 맵 초기화
        TextAsset conversationTextAsset = _resourceMap.LoadResource<TextAsset>("Languages/Conversation_Korean");
        ConversationContainer conversationContainer = JsonUtility.FromJson<ConversationContainer>(conversationTextAsset.text);
        foreach (var node in conversationContainer.Nodes)
            _conversationMap[node.Key] = node;
    }

    /// <summary>
    /// 키를 사용하여 문자열 데이터를 가져옵니다.
    /// </summary>
    /// <param name="key">문자열 키</param>
    /// <returns>문자열 데이터</returns>
    public string GetString(string key)
    {
        if (_stringMap.TryGetValue(key, out var node))
            return node.Value;

        Debug.LogWarning($"{key} 문자열이 존재하지 않습니다.");
        return string.Empty;
    }

    /// <summary>
    /// 키를 사용하여 대화 데이터를 가져옵니다.
    /// </summary>
    /// <param name="key">대화 키</param>
    /// <returns>대화 텍스트</returns>
    public string GetConversationText(string key)
    {
        if (_conversationMap.TryGetValue(key, out var conversation))
            return conversation.Text;

        Debug.LogWarning($"{key} Conversation이 존재하지 않습니다.");
        return string.Empty;
    }
}