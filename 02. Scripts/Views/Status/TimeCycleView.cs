using TMPro;

namespace GamePlay.Views
{
    /// <summary>
    /// 시간 흐름 UI를 관리하는 뷰 클래스.
    /// </summary>
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

        /// <summary>
        /// 특정 TimeView 가져오기.
        /// </summary>
        /// <param name="index">TimeViewKey의 인덱스.</param>
        /// <returns>TimeView.</returns>
        public TimeView GetTimeView(int index)
        {
            return Get<TimeView>(index);
        }
    }
}


