using TMPro;

namespace GamePlay.Views
{
    /// <summary>
    /// 스테이지와 관련된 UI를 관리하는 뷰 클래스.
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