using GamePlay.Scene;
using System;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// �� ��(Scene)�� ���õ� ������ �����ϴ� Ŭ����.
    /// �� �����Ϳ� Terrain Culling(����ȭ) ������ �����մϴ�.
    /// </summary>
    [Serializable]
    public class MountainSceneConfig : ITerrainCullerModel
    {
        [Header("----- ��(��) ���� -----")]
        [SerializeField] TextAsset _cellDatasTextAsset;
        public TextAsset CellDatasTextAsset => _cellDatasTextAsset;

        [Header("----- Terrain Culling(����ȭ) -----")]
        [SerializeField] float _cullingUpdateSpan;
        [SerializeField] float _cullingThreshold;
        float ITerrainCullerModel.UpdateSpan => _cullingUpdateSpan;
        float ITerrainCullerModel.Threshold => _cullingThreshold;
    }
}


