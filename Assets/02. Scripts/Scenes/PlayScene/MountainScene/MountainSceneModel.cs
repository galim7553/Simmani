using GamePlay.Configs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Scene
{
    public class MountainSceneModel
    {
        public MountainSceneConfig Config { get; private set; }

        public MountainData MountainData { get; private set; }

        public MountainSceneModel(MountainSceneConfig config)
        {
            Config = config;

            MountainData = new MountainData(JsonUtility.FromJson<CellDataContainer>(Config.CellDatasTextAsset.text));
        }
    }

}

