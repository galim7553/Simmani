namespace GamePlay.Modules.AI
{
    /// <summary>
    /// ��� ���� �ൿ �������� �����ϴ� �������̽��Դϴ�.
    /// </summary>
    public interface IPathFollowingBehaviourConfig : IBehaviourConfig
    {
        public enum LoopType
        {
            FowardLoop,
            PingPongLoop
        }

        /// <summary>��� �ݺ� �����Դϴ�.</summary>
        public LoopType Type { get; }

        /// <summary>�ӵ� �����Դϴ�.</summary>
        public float SpeedRatio { get; }

        /// <summary>�극��ũ �Ÿ��Դϴ�.</summary>
        public float BrakingDistance { get; }
    }
}