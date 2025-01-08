using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 지면(Terrain, Collider 등)을 처리하는 기능을 제공하는 인터페이스입니다.
    /// </summary>
    /// <typeparam name="T">지면 타입(Terrain, Collider 등)</typeparam>
    public interface IGroundHolder<T> : IModule
    {
        /// <summary>
        /// 지면을 설정합니다.
        /// 제네릭 타입 T로 지면을 받아 처리합니다.
        /// </summary>
        /// <param name="ground">설정할 지면 객체</param>
        void SetGround(T ground);

        /// <summary>
        /// 지면과의 상대적인 오프셋 값을 수동으로 설정합니다.
        /// </summary>
        /// <param name="offset">오프셋 값</param>
        void SetOffset(float offset);

        /// <summary>
        /// 현재 오브젝트의 위치를 기준으로 오프셋을 자동으로 계산하고 설정합니다.
        /// </summary>
        float SetOffsetAuto();
    }
}

