using TMPro;
using UnityEngine.UI;

namespace GamePlay.Views
{
    /// <summary>
    /// ���� ��Ű UI�� �����ϴ� �� Ŭ����.
    /// </summary>
    public class HotKeyView : ViewBase
    {
        public enum ImageKey
        {
            ItemImage,
        }
        public enum TMPKey
        {
            CountText,
        }

        private void Awake()
        {
            Bind<Image>(typeof(ImageKey));
            Bind<TextMeshProUGUI>(typeof(TMPKey));
        }
    }

}