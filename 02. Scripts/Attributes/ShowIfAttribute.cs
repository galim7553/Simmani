using UnityEngine;

/// <summary>
/// 조건에 따라 Inspector에서 특정 속성을 표시하거나 숨기기 위한 어트리뷰트.
/// </summary>
public class ShowIfAttribute : PropertyAttribute
{
    /// <summary>
    /// 속성을 표시할 조건이 되는 필드 이름.
    /// </summary>
    public string conditionFieldName;

    /// <summary>
    /// ShowIfAttribute 생성자.
    /// </summary>
    /// <param name="conditionFieldName">조건으로 사용할 필드의 이름</param>
    public ShowIfAttribute(string conditionFieldName)
    {
        this.conditionFieldName = conditionFieldName;
    }
}