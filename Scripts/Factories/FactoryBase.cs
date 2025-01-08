using GamePlay.Hubs;

namespace GamePlay.Factories
{
    /// <summary>
    /// ������Ʈ ������ �⺻ ������ �����ϴ� �߻� Ŭ����.
    /// </summary>
    /// <typeparam name="T1">������ ������Ʈ�� Ÿ��(ObjectHub ���).</typeparam>
    /// <typeparam name="T2">������Ʈ�� ������ ���� Ÿ��.</typeparam>
    public abstract class FactoryBase<T1, T2> where T1 : ObjectHub
    {
        protected PoolManager _poolManager;

        /// <summary>
        /// ���丮 ������.
        /// </summary>
        /// <param name="poolManager">������Ʈ Ǯ���� �����ϴ� PoolManager �ν��Ͻ�.</param>
        public FactoryBase(PoolManager poolManager)
        {
            _poolManager = poolManager;
        }

        /// <summary>
        /// ������Ʈ�� �����ϰų� Ǯ���� �����ɴϴ�.
        /// </summary>
        /// <param name="model">������ ������Ʈ�� ������ ��.</param>
        /// <returns>������ ������Ʈ.</returns>
        public abstract T1 Create(T2 model);
    }
}
