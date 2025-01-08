using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Datas
{
    /// <summary>
    /// ���̵� ��.
    /// </summary>
    public class DifficultyModel : ModuleModelBase<IDifficultyConfig>, IDifficultyModel
    {
        /// <summary>
        /// DifficultyModel ������. ���̵� ������ �޾� �ʱ�ȭ�մϴ�.
        /// </summary>
        /// <param name="config">���̵� ���� ��ü</param>
        public DifficultyModel(IDifficultyConfig config) : base(config)
        {
        }

        public bool GetIsSansam()
        {
            return Random.value < Config.SansamRate;
        }
    }
}


