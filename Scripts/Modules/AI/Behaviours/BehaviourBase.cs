namespace GamePlay.Modules.AI
{

    /// <summary>
    /// AI �ൿ�� �⺻ ������ �����ϴ� �߻� Ŭ�����Դϴ�.
    /// </summary>
    /// <typeparam name="TConfig">�ൿ �������� Ÿ��.</typeparam>
    /// <typeparam name="TAI">AI �������̽��� Ÿ��.</typeparam>
    public abstract class BehaviourBase<TConfig, TAI> : IBehaviour where TConfig : IBehaviourConfig where TAI : IAI
    {
        protected TConfig _config;
        protected TAI _ai;

        /// <summary>
        /// �ൿ�� �⺻ ������.
        /// </summary>
        /// <param name="config">�ൿ ������.</param>
        /// <param name="ai">AI ��ü.</param>
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


