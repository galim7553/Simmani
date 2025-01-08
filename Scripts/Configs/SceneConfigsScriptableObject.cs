using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Configs
{
    [CreateAssetMenu(fileName = "SceneConfigs", menuName = "GameConfig/SceneConfigs")]
    public class SceneConfigsScriptableObject : ScriptableObject
    {
        [SerializeField] MountainSceneConfig _mountainSceneConfig;
        public MountainSceneConfig MountainSceneConfig => _mountainSceneConfig;
    }
}


