using UnityEditor;
using UnityEngine;

/// <summary>
/// ShowIfAttribute�� ó���Ͽ� Inspector�� ���Ǻ� ǥ�� ����� �����ϴ� Ŀ���� ������Ƽ ��ξ�.
/// </summary>
[CustomPropertyDrawer(typeof(ShowIfAttribute))]
public class ShowIfDrawer : PropertyDrawer
{
    /// <summary>
    /// ������ �����Ǿ��� �� �Ӽ��� Inspector�� �׸��ϴ�.
    /// </summary>
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ShowIfAttribute showIfAttribute = (ShowIfAttribute)attribute;
        SerializedProperty conditionProperty = property.serializedObject.FindProperty(showIfAttribute.conditionFieldName);

        if (conditionProperty != null && conditionProperty.propertyType == SerializedPropertyType.Boolean)
        {
            // ������ true�� ��� �Ӽ��� Inspector�� ǥ��
            if (conditionProperty.boolValue)
            {
                EditorGUI.PropertyField(position, property, label, true);
            }
        }
        else
        {
            Debug.LogWarning("ShowIf attribute condition field must be of type bool.");
        }
    }

    /// <summary>
    /// ���ǿ� ���� Inspector�� ǥ�õǴ� �Ӽ��� ���̸� �����մϴ�.
    /// </summary>
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        ShowIfAttribute showIfAttribute = (ShowIfAttribute)attribute;
        SerializedProperty conditionProperty = property.serializedObject.FindProperty(showIfAttribute.conditionFieldName);

        if (conditionProperty != null && conditionProperty.propertyType == SerializedPropertyType.Boolean)
        {
            return conditionProperty.boolValue ? EditorGUI.GetPropertyHeight(property, label, true) : 0f;
        }

        return EditorGUI.GetPropertyHeight(property, label, true);
    }
}