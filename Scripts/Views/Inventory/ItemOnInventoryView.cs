using UnityEngine.UI;

namespace GamePlay.Views
{
    /// <summary>
    /// �κ��丮���� �������� UI�� ó���ϴ� ��.
    /// </summary>
    public class ItemOnInventoryView : ViewBase
    {
        public enum ImageKey
        {
            ItemImage
        }

        Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
            Bind<Image>(typeof(ImageKey));
        }

        /// <summary>
        /// ���� �ܰ��� ȿ�� Ȱ��ȭ ���¸� �����մϴ�.
        /// </summary>
        public void SetAlphaOutlineActive(bool isActive)
        {
            // TBD: �ܰ��� Ȱ��ȭ ���� ���� �ʿ�
        }
    }
}


