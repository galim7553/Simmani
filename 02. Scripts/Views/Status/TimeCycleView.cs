using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GamePlay.Views
{
    public class TimeCycleView : ViewBase
    {
        public enum TimeViewKey
        {
            PrevTimeView,
            CurTimeView,
            NextTimeView,
        }
        public enum TMPKey
        {
            TimeText,
            DayText,
        }

        private void Awake()
        {
            Bind<TimeView>(typeof(TimeViewKey));
            Bind<TextMeshProUGUI>(typeof(TMPKey));
        }

        public TimeView GetTimeView(int index)
        {
            return Get<TimeView>(index);
        }
    }
}


