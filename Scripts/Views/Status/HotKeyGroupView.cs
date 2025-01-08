using System.Collections.Generic;

namespace GamePlay.Views
{
    /// <summary>
    /// ��Ű UI �׷� ��.
    /// </summary>
    public class HotKeyGroupView : ViewBase
    {
        HotKeyView[] _hotKeyViews;

        /// <summary>
        /// ��Ű �� �迭.
        /// </summary>
        public IReadOnlyList<HotKeyView> HotKeyViews => _hotKeyViews;
        private void Awake()
        {
            _hotKeyViews = GetComponentsInChildren<HotKeyView>(true);
        }
    }

}