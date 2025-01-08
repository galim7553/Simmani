using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Configs
{
    [CreateAssetMenu(fileName = "GamePlayConfigs", menuName = "GameConfig/GamePlayConfigs")]
    public class GamePlayConfigsScriptableObject : ScriptableObject
    {
        [SerializeField] GamePlayConfig _gamePlayConfig;
        public GamePlayConfig GamePlayConfig => _gamePlayConfig;

        [Header("----- ³­ÀÌµµ -----")]
        [SerializeField] DifficultyConfig _easyDifficulty = new DifficultyConfig(Datas.IDifficultyConfig.DifficultyType.Easy);
        [SerializeField] DifficultyConfig _normalDifficulty = new DifficultyConfig(Datas.IDifficultyConfig.DifficultyType.Normal);
        [SerializeField] DifficultyConfig _difficultDifficulty = new DifficultyConfig(Datas.IDifficultyConfig.DifficultyType.Difficult);

        public DifficultyConfig EasyDifficulty => _easyDifficulty;
        public DifficultyConfig NormalDifficulty => _normalDifficulty;
        public DifficultyConfig DifficultDifficulty => _difficultDifficulty;

    }
}