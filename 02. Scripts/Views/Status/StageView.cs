using TMPro;

namespace GamePlay.Views
{
    /// <summary>
    /// ���������� ���õ� UI�� �����ϴ� �� Ŭ����.
    /// </summary>
    public class StageView : ViewBase
    {
        public enum TMPKey
        {
            SansamCountText
        }

        private void Awake()
        {
            Bind<TextMeshProUGUI>(typeof(TMPKey));
        }
    }

}