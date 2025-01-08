using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 이동 가능한 객체에 대해 이동 동작을 정의하는 인터페이스.
    /// </summary>
    public interface IMovable
    {
        /// <summary>
        /// 입력 벡터를 기반으로 객체를 이동합니다.
        /// </summary>
        /// <param name="inputVector">이동 방향 및 크기를 나타내는 2D 벡터</param>
        void Move(Vector2 inputVector);
    }
}