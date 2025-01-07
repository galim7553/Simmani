namespace GamePlay.Commands
{
    /// <summary>
    /// Hero 모델 명령의 기본 구현 클래스.
    /// </summary>
    public abstract class HeroModelCommandBase : IHeroModelCommand
    {
        protected IHeroModelCommandConfig _config;

        /// <summary>
        /// HeroModelCommandBase 생성자.
        /// </summary>
        /// <param name="config">명령 설정.</param>
        public HeroModelCommandBase(IHeroModelCommandConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// 명령을 대상에 적용.
        /// </summary>
        /// <param name="target">명령이 적용될 대상.</param>
        public abstract void Apply(IHeroModel target);

        /// <summary>
        /// 명령을 대상에서 제거.
        /// </summary>
        /// <param name="target">명령이 제거될 대상.</param>
        public abstract void Disapply(IHeroModel target);
    }

    /// <summary>
    /// Hero 모델 명령의 구체적 구현 클래스.
    /// </summary>
    public class HeroModelCommand : HeroModelCommandBase, IAppliableCommand<IHeroModel>
    {

        /// <summary>
        /// HeroModelCommand 생성자.
        /// </summary>
        /// <param name="config">명령 설정.</param>
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


