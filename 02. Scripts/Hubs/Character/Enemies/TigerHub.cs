namespace GamePlay.Hubs
{
    /// <summary>
    /// 호랑이 적을 관리하는 클래스.
    /// EnemyHub를 상속받아 추가적인 전투 상태 로직을 구현합니다.
    /// </summary>
    public class TigerHub : EnemyHub
    {
        /// <summary>
        /// TigerHub 초기화. EnemyHub의 기본 초기화 로직을 호출한 후 추가 전투 상태 이벤트를 설정합니다.
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


