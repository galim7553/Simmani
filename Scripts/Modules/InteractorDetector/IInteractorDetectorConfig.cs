using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// ��ȣ�ۿ� �������� ������ �������̽�.
    /// </summary>
    public interface IInteractorDetectorConfig
    {
        /// <summary>���� ������ �ִ� �Ÿ�.</summary>
        float RayDistance { get; }

        /// <summary>���� ������ ��ȣ�ۿ� ������ ���̾� ����ũ.</summary>
        LayerMask InteractableLayerMask { get; }
    }
}


