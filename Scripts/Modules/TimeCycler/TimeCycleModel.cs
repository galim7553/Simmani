using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// �ð� �ֱ⸦ �����ϴ� �� Ŭ����.
    /// </summary>
    public class TimeCycleModel : DataDependantModelBase<ITimeCycleConfig, TimeCycleData>, ITimeCycleModel
    {
        readonly DateTime _initDateTime = new DateTime(1495, 2, 4);

        DateTime _lastEventTime;

        /// <summary>���� ���� �ð�.</summary>
        public DateTime DateTime => _data.DateTime;

        /// <summary>���� ��� �� ��.</summary>
        public int GameDay => (DateTime - _initDateTime).Days;

        /// <summary>�ѱ��� �ð�(12�� ����).</summary>
        public int KoreanHour => ((DateTime.Hour + 1) / 2) % 12;

        /// <summary>���� ��� �� �ؽ�Ʈ Ű.</summary>
        public string GameDayTextKey => string.Format(Config.GameDayTextKeyFormat, GameDay % 5);

        /// <summary>�ѱ��� �ð� �ؽ�Ʈ Ű.</summary>
        public string KoreanHourTextKey => string.Format(Config.KoreanHourTextKeyFormat, KoreanHour);

        /// <summary>�ѱ��� �ð� ������ ���.</summary>
        public string KoreanHourSpritePath => string.Format(Config.KoreanHourSpritePathFormat, KoreanHour);

        /// <summary>�ð� ���� �̺�Ʈ (�ð� ����).</summary>
        public event Action OnHourChanged;


        /// <summary>
        /// �ð� �ֱ� �� ������.
        /// </summary>
        /// <param name="config">�ð� �ֱ� ����.</param>
        /// <param name="data">�ð� ������.</param>
        public TimeCycleModel(ITimeCycleConfig config, TimeCycleData data) : base(config, data)
        {
            _data.Initialize();
        }

        /// <summary>
        /// ������ ���� �ʱ� �ð��� ����.
        /// </summary>
        /// <param name="level">���� ��ȣ.</param>
        public void SetDateTimeByLevel(int level)
        {
            DateTime newDateTime = _initDateTime;
            newDateTime = newDateTime.AddDays(level * 5);
            newDateTime = newDateTime.AddHours(12);
            _data.SetDateTime(newDateTime);
        }

        /// <summary>
        /// �� ������ �ð� �����͸� ������Ʈ.
        /// </summary>
        /// <param name="deltaTime">��� �ð�(��).</param>
        public void OnUpdate(float deltaTime)
        {
            _data.AddSeconds(deltaTime * Config.TimeRatio);

            if(DateTime.Hour != _lastEventTime.Hour)
            {
                _lastEventTime = DateTime;
                OnHourChanged?.Invoke();
            }
        }
    }
}


