using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Views
{
    public class HotKeyGroupView : ViewBase
    {
        HotKeyView[] _hotKeyViews;
        public IReadOnlyList<HotKeyView> HotKeyViews => _hotKeyViews;
        private void Awake()
        {
            _hotKeyViews = GetComponentsInChildren<HotKeyView>(true);
        }
    }

}