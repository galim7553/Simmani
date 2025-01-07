using UnityEditor;
using UnityEngine;

/// <summary>
/// ShowIfAttribute를 처리하여 Inspector에 조건부 표시 기능을 구현하는 커스텀 프로퍼티 드로어.
/// </summary>
[CustomPropertyDrawer(typeof(ShowIfAttribute))]
public class ShowIfDrawer : PropertyDrawer
{
    /// <summary>
    /// 조건이 충족되었을 때 속성을 Inspector에 그립니다.
    /// </summary>
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ShowIfAttribute showIfAttribute = (ShowIfAttribute)attribute;
        SerializedProperty conditionProperty = property.serializedObject.FindProperty(showIfAttribute.conditionFieldName);

        if (conditionProperty != null && conditionProperty.propertyType == SerializedPropertyType.Boolean)
        {
            // 조건이 true일 경우 속성을 Inspector에 표시
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
    /// 조건에 따라 Inspector에 표시되는 속성의 높이를 설정합니다.
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