namespace GamePlay.Hubs
{
    /// <summary>
    /// ȣ���� ���� �����ϴ� Ŭ����.
    /// EnemyHub�� ��ӹ޾� �߰����� ���� ���� ������ �����մϴ�.
    /// </summary>
    public class TigerHub : EnemyHub
    {
        /// <summary>
        /// TigerHub �ʱ�ȭ. EnemyHub�� �⺻ �ʱ�ȭ ������ ȣ���� �� �߰� ���� ���� �̺�Ʈ�� �����մϴ�.
        /// </summary>
        public override void Initialize()
        {
            if (!Modules.HasInitialized)
            {
                LogUninitializedModuleError();
                return;
            }

            base.Initialize();

            _combatStater.AddEnterAction(GamePlay.Modules.ICombatStater.CombatState.Attacking, OnCombatAttackingEntered);
            _combatStater.AddExitAction(GamePlay.Modules.ICombatStater.CombatState.Attacking, OnCombatAttackingExited);
        }

        void OnCombatAttackingEntered()
        {
            _follower.Pause(true);
            _enemyAI.Pause(true);
        }
        void OnCombatAttackingExited()
        {
            _follower.Pause(false);
            _enemyAI.Pause(false);
        }
    }
}


