using System;

namespace GamePlay.Datas
{
    /// <summary>
    /// 스테이지 모델의 동작을 정의하는 인터페이스입니다.
    /// </summary>
    public interface IStageModel
    {
        IStageConfig Config { get; }

        /// <summary>현재 스테이지 레벨.</summary>
        int Level { get; }

        /// <summary>현재 스테이지의 목표 산삼 개수.</summary>
        int SansamCount { get; }

        /// <summary>레벨 변경 이벤트.</summary>
        event Action OnLevelChanged;

        /// <summary>스테이지 레벨을 증가시킵니다.</summary>
        void AddLevel();

        /// <summary>제출된 산삼 개수를 추가합니다.</summary>
        void AddSubmitedSansamCount(int count);

        /// <summary>계산된 적 키를 반환합니다.</summary>
        string GetEnemyKey();

        /// <summary>적 생성 간격을 반환합니다.</summary>
        float GetEnemySpawnSpan();
    }
}

