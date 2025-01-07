using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Datas
{
    /// <summary>
    /// 난이도 모델.
    /// </summary>
    public class DifficultyModel : ModuleModelBase<IDifficultyConfig>, IDifficultyModel
    {
        /// <summary>
        /// DifficultyModel 생성자. 난이도 설정을 받아 초기화합니다.
        /// </summary>
        /// <param name="config">난이도 설정 객체</param>
        public DifficultyModel(IDifficultyConfig config) : base(config)
        {
        }

        public bool GetIsSansam()
        {
            return Random.value < Config.SansamRate;
        }
    }
}


