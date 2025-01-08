using TMPro;

namespace GamePlay.Views
{
    /// <summary>
    /// �ð� �帧 UI�� �����ϴ� �� Ŭ����.
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
        /// Ư�� TimeView ��������.
        /// </summary>
        /// <param name="index">TimeViewKey�� �ε���.</param>
        /// <returns>TimeView.</returns>
        public TimeView GetTimeView(int index)
        {
            return Get<TimeView>(index);
        }
    }
}


