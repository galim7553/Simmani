using System.Collections.Generic;
using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// Ÿ�� Ž�� ���� �������̽�.
    /// </summary>
    public interface ITargetFinderConfig
    {
        /// <summary>Ž�� ����� ���̾� ����ũ.</summary>
        LayerMask TargetLayerMask { get; }

        /// <summary>Ž�� ������ Ÿ�� �±� ���.</summary>
        IReadOnlyList<CharacterTagType> TargetTags { get; }

        /// <summary>Ž�� ������ �ִ� ��� ��.</summary>
        int DetectionCountLimit { get; }
    }
}