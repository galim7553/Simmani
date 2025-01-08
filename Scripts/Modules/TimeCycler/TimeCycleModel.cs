using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// 시간 주기를 관리하는 모델 클래스.
    /// </summary>
    public class TimeCycleModel : DataDependantModelBase<ITimeCycleConfig, TimeCycleData>, ITimeCycleModel
    {
        readonly DateTime _initDateTime = new DateTime(1495, 2, 4);

        DateTime _lastEventTime;

        /// <summary>현재 게임 시간.</summary>
        public DateTime DateTime => _data.DateTime;

        /// <summary>게임 경과 일 수.</summary>
        public int GameDay => (DateTime - _initDateTime).Days;

        /// <summary>한국식 시간(12지 기준).</summary>
        public int KoreanHour => ((DateTime.Hour + 1) / 2) % 12;

        /// <summary>게임 경과 일 텍스트 키.</summary>
        public string GameDayTextKey => string.Format(Config.GameDayTextKeyFormat, GameDay % 5);

        /// <summary>한국식 시간 텍스트 키.</summary>
        public string KoreanHourTextKey => string.Format(Config.KoreanHourTextKeyFormat, KoreanHour);

        /// <summary>한국식 시간 아이콘 경로.</summary>
        public string KoreanHourSpritePath => string.Format(Config.KoreanHourSpritePathFormat, KoreanHour);

        /// <summary>시간 변경 이벤트 (시간 단위).</summary>
        public event Action OnHourChanged;


        /// <summary>
        /// 시간 주기 모델 생성자.
        /// </summary>
        /// <param name="config">시간 주기 설정.</param>
        /// <param name="data">시간 데이터.</param>
        public TimeCycleModel(ITimeCycleConfig config, TimeCycleData data) : base(config, data)
        {
            _data.Initialize();
        }

        /// <summary>
        /// 레벨에 따라 초기 시간을 설정.
        /// </summary>
        /// <param name="level">레벨 번호.</param>
        public void SetDateTimeByLevel(int level)
        {
            DateTime newDateTime = _initDateTime;
            newDateTime = newDateTime.AddDays(level * 5);
            newDateTime = newDateTime.AddHours(12);
            _data.SetDateTime(newDateTime);
        }

        /// <summary>
        /// 매 프레임 시간 데이터를 업데이트.
        /// </summary>
        /// <param name="deltaTime">경과 시간(초).</param>
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


