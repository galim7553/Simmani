using UnityEngine.UI;

namespace GamePlay.Views
{
    /// <summary>
    /// �ð� ���� UI�� �����ϴ� TimeView Ŭ����.
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