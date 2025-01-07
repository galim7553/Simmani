namespace GamePlay.Modules.AI
{

    /// <summary>
    /// AI 행동의 기본 구현을 제공하는 추상 클래스입니다.
    /// </summary>
    /// <typeparam name="TConfig">행동 설정값의 타입.</typeparam>
    /// <typeparam name="TAI">AI 인터페이스의 타입.</typeparam>
    public abstract class BehaviourBase<TConfig, TAI> : IBehaviour where TConfig : IBehaviourConfig where TAI : IAI
    {
        protected TConfig _config;
        protected TAI _ai;

        /// <summary>
        /// 행동의 기본 생성자.
        /// </summary>
        /// <param name="config">행동 설정값.</param>
        /// <param name="ai">AI 객체.</param>
        public BehaviourBase(TConfig config, TAI ai)
        {
            _config = config;
            _ai = ai;
        }

        public abstract void Enter();
        public abstract void Exit();
        public virtual void Clear()
        {
        }
    }
}


