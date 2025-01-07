using UnityEngine.UI;

namespace GamePlay.Views
{
    /// <summary>
    /// �÷��̾� ĳ����(Hero)�� ����(ü��, ���¹̳�, �Ƿε�)�� ǥ���ϴ� UI ��.
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
        /// ���� �� �̹����� FillAmount ���� ����.
        /// </summary>
        /// <param name="index">ImageKey�� �ε���.</param>
        /// <param name="amount">0.0 ~ 1.0 ������ FillAmount ��.</param>
        public void SetImageFillAmount(int index, float amount)
        {
            GetImage(index).fillAmount = amount;
        }
    }
}


