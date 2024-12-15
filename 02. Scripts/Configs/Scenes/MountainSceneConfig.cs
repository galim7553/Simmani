using GamePlay.Scene;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Configs
{
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


