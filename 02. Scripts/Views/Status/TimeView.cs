using UnityEngine.UI;

namespace GamePlay.Views
{
    /// <summary>
    /// 시간 단위 UI를 관리하는 TimeView 클래스.
    /// </summary>
    public class TimeView : ViewBase
    {
        public enum ImageKey
        {
            TimeImage
        }

        private void Awake()
        {
            Bind<Image>(typeof(ImageKey));
        }
    }

}