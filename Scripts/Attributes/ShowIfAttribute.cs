using UnityEngine;

/// <summary>
/// ���ǿ� ���� Inspector���� Ư�� �Ӽ��� ǥ���ϰų� ����� ���� ��Ʈ����Ʈ.
/// </summary>
public class ShowIfAttribute : PropertyAttribute
{
    /// <summary>
    /// �Ӽ��� ǥ���� ������ �Ǵ� �ʵ� �̸�.
    /// </summary>
    public string conditionFieldName;

    /// <summary>
    /// ShowIfAttribute ������.
    /// </summary>
    /// <param name="conditionFieldName">�������� ����� �ʵ��� �̸�</param>
    public ShowIfAttribute(string conditionFieldName)
    {
        this.conditionFieldName = conditionFieldName;
    }
}