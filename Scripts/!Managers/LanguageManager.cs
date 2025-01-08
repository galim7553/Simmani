using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ڿ� ���� �������̽�.
/// Ű�� ����Ͽ� ���ڿ��� �������� ����� �����մϴ�.
/// </summary>
public interface IStringMap
{
    /// <summary>
    /// Ű�� ����Ͽ� ���ڿ��� ��ȯ�մϴ�.
    /// </summary>
    /// <param name="key">���ڿ� Ű</param>
    /// <returns>���ε� ���ڿ�</returns>
    string GetString(string key);
}

/// <summary>
/// ��ȭ �ؽ�Ʈ ���� �������̽�.
/// Ű�� ����Ͽ� ��ȭ �ؽ�Ʈ�� �������� ����� �����մϴ�.
/// </summary>
public interface IConversationMap
{
    /// <summary>
    /// Ű�� ����Ͽ� ��ȭ �ؽ�Ʈ�� ��ȯ�մϴ�.
    /// </summary>
    /// <param name="key">��ȭ Ű</param>
    /// <returns>���ε� ��ȭ �ؽ�Ʈ</returns>
    string GetConversationText(string key);
}

/// <summary>
/// ���� ��� Ÿ��.
/// </summary>
public enum LanguageType
{
    Korean,
    English
}

/// <summary>
/// ��� �����͸� ��� �����̳� Ŭ����.
/// </summary>
[Serializable]
public class LanguageContainer
{
    [SerializeField] LanguageNode[] _nodes; // ��� ������ ��� �迭

    /// <summary>
    /// �б� ���� ��� ������ ��� ����Ʈ.
    /// </summary>
    public IReadOnlyList<LanguageNode> Nodes => _nodes;
}

/// <summary>
/// ��ȭ �����͸� ��� �����̳� Ŭ����.
/// </summary>
[Serializable]
public class ConversationContainer
{
    [SerializeField] ConversationNode[] _nodes; // ��ȭ ������ ��� �迭

    /// <summary>
    /// �б� ���� ��ȭ ������ ��� ����Ʈ.
    /// </summary>
    public IReadOnlyList<ConversationNode> Nodes => _nodes;
}

/// <summary>
/// ��� �������� Ű-�� ���� ��Ÿ���� Ŭ����.
/// </summary>
[Serializable]
public class LanguageNode
{
    [SerializeField] string _key; // ��� Ű
    [SerializeField] string _value; // ��� ��

    /// <summary>
    /// ��� ������ Ű.
    /// </summary>
    public string Key => _key;

    /// <summary>
    /// ��� ������ ��.
    /// </summary>
    public string Value => _value;
}

/// <summary>
/// ��ȭ �������� Ű-�ؽ�Ʈ ���� ��Ÿ���� Ŭ����.
/// </summary>
[Serializable]
public class ConversationNode
{
    [SerializeField] string _key; // ��ȭ Ű
    [SerializeField] string _text; // ��ȭ �ؽ�Ʈ

    /// <summary>
    /// ��ȭ ������ Ű.
    /// </summary>
    public string Key => _key;

    /// <summary>
    /// ��ȭ ������ �ؽ�Ʈ.
    /// </summary>
    public string Text => _text;
}

/// <summary>
/// ��� �� ��ȭ �����͸� �����ϴ� Ŭ����.
/// ���ҽ� ���� ����Ͽ� �����͸� �ε��ϰ� Ű�� ���� �����͸� �˻��մϴ�.
/// </summary>
public class LanguageManager : IStringMap, IConversationMap
{
    IResourceMap _resourceMap; // ���ҽ� ���� �������̽�
    Dictionary<string, LanguageNode> _stringMap = new Dictionary<string, LanguageNode>(); // ��� ������ ��
    Dictionary<string, ConversationNode> _conversationMap = new Dictionary<string, ConversationNode>(); // ��ȭ ������ ��

    /// <summary>
    /// LanguageManager ������.
    /// ���ҽ� �ʿ��� �����͸� �ε��ϰ� �ʱ�ȭ�մϴ�.
    /// </summary>
    /// <param name="resourceMap">���ҽ� ���� �������̽�</param>
    public LanguageManager(IResourceMap resourceMap)
    {
        _resourceMap = resourceMap;

        // ��� ������ �ε� �� �� �ʱ�ȭ
        TextAsset langTextAsset = _resourceMap.LoadResource<TextAsset>("Languages/Korean");
        LanguageContainer languageContainer = JsonUtility.FromJson<LanguageContainer>(langTextAsset.text);
        foreach (var node in languageContainer.Nodes)
            _stringMap[node.Key] = node;

        // ��ȭ ������ �ε� �� �� �ʱ�ȭ
        TextAsset conversationTextAsset = _resourceMap.LoadResource<TextAsset>("Languages/Conversation_Korean");
        ConversationContainer conversationContainer = JsonUtility.FromJson<ConversationContainer>(conversationTextAsset.text);
        foreach (var node in conversationContainer.Nodes)
            _conversationMap[node.Key] = node;
    }

    /// <summary>
    /// Ű�� ����Ͽ� ���ڿ� �����͸� �����ɴϴ�.
    /// </summary>
    /// <param name="key">���ڿ� Ű</param>
    /// <returns>���ڿ� ������</returns>
    public string GetString(string key)
    {
        if (_stringMap.TryGetValue(key, out var node))
            return node.Value;

        Debug.LogWarning($"{key} ���ڿ��� �������� �ʽ��ϴ�.");
        return string.Empty;
    }

    /// <summary>
    /// Ű�� ����Ͽ� ��ȭ �����͸� �����ɴϴ�.
    /// </summary>
    /// <param name="key">��ȭ Ű</param>
    /// <returns>��ȭ �ؽ�Ʈ</returns>
    public string GetConversationText(string key)
    {
        if (_conversationMap.TryGetValue(key, out var conversation))
            return conversation.Text;

        Debug.LogWarning($"{key} Conversation�� �������� �ʽ��ϴ�.");
        return string.Empty;
    }
}