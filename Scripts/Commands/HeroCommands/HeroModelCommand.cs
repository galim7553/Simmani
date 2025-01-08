namespace GamePlay.Commands
{
    /// <summary>
    /// Hero �� ����� �⺻ ���� Ŭ����.
    /// </summary>
    public abstract class HeroModelCommandBase : IHeroModelCommand
    {
        protected IHeroModelCommandConfig _config;

        /// <summary>
        /// HeroModelCommandBase ������.
        /// </summary>
        /// <param name="config">��� ����.</param>
        public HeroModelCommandBase(IHeroModelCommandConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// ����� ��� ����.
        /// </summary>
        /// <param name="target">����� ����� ���.</param>
        public abstract void Apply(IHeroModel target);

        /// <summary>
        /// ����� ��󿡼� ����.
        /// </summary>
        /// <param name="target">����� ���ŵ� ���.</param>
        public abstract void Disapply(IHeroModel target);
    }

    /// <summary>
    /// Hero �� ����� ��ü�� ���� Ŭ����.
    /// </summary>
    public class HeroModelCommand : HeroModelCommandBase, IAppliableCommand<IHeroModel>
    {

        /// <summary>
        /// HeroModelCommand ������.
        /// </summary>
        /// <param name="config">��� ����.</param>
        public HeroModelCommand(IHeroModelCommandConfig config) : base(config)
        {
        }

        public override void Apply(IHeroModel target)
        {
            target.ExecuteCommand(_config.Type, _config.Amount);
        }

        public override void Disapply(IHeroModel target)
        {
            target.ExecuteCommand(_config.Type, -_config.Amount);
        }
    }
}


