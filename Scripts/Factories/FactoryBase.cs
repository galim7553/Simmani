using GamePlay.Hubs;

namespace GamePlay.Factories
{
    /// <summary>
    /// 오브젝트 생성의 기본 동작을 정의하는 추상 클래스.
    /// </summary>
    /// <typeparam name="T1">생성할 오브젝트의 타입(ObjectHub 기반).</typeparam>
    /// <typeparam name="T2">오브젝트에 설정할 모델의 타입.</typeparam>
    public abstract class FactoryBase<T1, T2> where T1 : ObjectHub
    {
        protected PoolManager _poolManager;

        /// <summary>
        /// 팩토리 생성자.
        /// </summary>
        /// <param name="poolManager">오브젝트 풀링을 관리하는 PoolManager 인스턴스.</param>
        public FactoryBase(PoolManager poolManager)
        {
            _poolManager = poolManager;
        }

        /// <summary>
        /// 오브젝트를 생성하거나 풀에서 가져옵니다.
        /// </summary>
        /// <param name="model">생성할 오브젝트에 설정할 모델.</param>
        /// <returns>생성된 오브젝트.</returns>
        public abstract T1 Create(T2 model);
    }
}
