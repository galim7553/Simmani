using System.Collections;
using System.Collections.Generic;
using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Datas
{
    public class DifficultyModel : ModuleModelBase<IDifficultyConfig>, IDifficultyModel
    {
        public DifficultyModel(IDifficultyConfig config) : base(config)
        {
        }

        public bool GetIsSansam()
        {
            return Random.value < Config.SansamRate;
        }
    }
}


