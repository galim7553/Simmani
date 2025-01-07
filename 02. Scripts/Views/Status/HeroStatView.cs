using UnityEngine.UI;

namespace GamePlay.Views
{
    /// <summary>
    /// 플레이어 캐릭터(Hero)의 스탯(체력, 스태미나, 피로도)을 표시하는 UI 뷰.
    /// </summary>
    public class HeroStatView : ViewBase
    {
        public enum ImageKey
        {
            HpBar,
            StaminaBar,
            FatigueBar,
        }

        private void Awake()
        {
            Bind<Image>(typeof(ImageKey));
        }

        /// <summary>
        /// 상태 바 이미지의 FillAmount 값을 설정.
        /// </summary>
        /// <param name="index">ImageKey의 인덱스.</param>
        /// <param name="amount">0.0 ~ 1.0 사이의 FillAmount 값.</param>
        public void SetImageFillAmount(int index, float amount)
        {
            GetImage(index).fillAmount = amount;
        }
    }
}


