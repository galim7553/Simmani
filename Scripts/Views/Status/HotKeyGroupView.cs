using System.Collections.Generic;

namespace GamePlay.Views
{
    /// <summary>
    /// ÇÖÅ° UI ±×·ì ºä.
    /// </summary>
    public class HotKeyGroupView : ViewBase
    {
        HotKeyView[] _hotKeyViews;

        /// <summary>
        /// ÇÖÅ° ºä ¹è¿­.
        /// </summary>
        public IReadOnlyList<HotKeyView> HotKeyViews => _hotKeyViews;
        private void Awake()
        {
            _hotKeyViews = GetComponentsInChildren<HotKeyView>(true);
        }
    }

}