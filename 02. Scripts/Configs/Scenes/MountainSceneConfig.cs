using GamePlay.Scene;
using System;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// 산 씬(Scene)과 관련된 설정을 정의하는 클래스.
    /// 맵 데이터와 Terrain Culling(최적화) 설정을 포함합니다.
    /// </summary>
    [Serializable]
    public class MountainSceneConfig : ITerrainCullerModel
    {
        [Header("----- 맵(산) 정보 -----")]
        [SerializeField] TextAsset _cellDatasTextAsset;
        public TextAsset CellDatasTextAsset => _cellDatasTextAsset;

        [Header("----- Terrain Culling(최적화) -----")]
        [SerializeField] float _cullingUpdateSpan;
        [SerializeField] float _cullingThreshold;
        float ITerrainCullerModel.UpdateSpan => _cullingUpdateSpan;
        float ITerrainCullerModel.Threshold => _cullingThreshold;
    }
}


