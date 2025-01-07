using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 데미지를 송출하는 기능을 제공하는 인터페이스.
    /// </summary>
    public interface IDamageSender : IModule
    {
        /// <summary>
        /// 충돌체(Collider)를 통해 데미지 송출을 처리.
        /// </summary>
        /// <param name="collider">충돌한 Collider 객체.</param>
        void OnHit(Collider collider);


        /// <summary>
        /// 데미지 수신자 객체를 직접 지정하여 데미지 송출을 처리.
        /// </summary>
        /// <param name="damageReceiver">데미지 수신자 객체.</param>
        void OnHit(IDamageReceiver damageReceiver);
    }
}


