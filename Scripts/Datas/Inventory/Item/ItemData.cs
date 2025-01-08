using System;
using UnityEngine;

namespace GamePlay.Datas
{
    /// <summary>
    /// 아이템 데이터를 저장하는 클래스입니다.
    /// </summary>
    [Serializable]
    public class ItemData
    {
        [SerializeField] string _key;
        [SerializeField] bool _hasEquipped;

        /// <summary>
        /// 아이템의 고유 키입니다.
        /// </summary>
        public string Key => _key;

        /// <summary>
        /// 아이템의 장착 여부입니다.
        /// </summary>
        public bool HasEquipped => _hasEquipped;

        public event Action OnHasEquippedChanged;

        /// <summary>
        /// 아이템 데이터를 초기화합니다.
        /// </summary>
        /// <param name="key">아이템의 고유 키</param>
        public ItemData(string key)
        {
            _key = key;
        }

        public void SetHasEquipped(bool hasEquipped)
        {
            _hasEquipped = hasEquipped;
            OnHasEquippedChanged?.Invoke();
        }
    }
}