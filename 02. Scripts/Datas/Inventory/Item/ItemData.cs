using System;
using UnityEngine;

namespace GamePlay.Datas
{
    /// <summary>
    /// ������ �����͸� �����ϴ� Ŭ�����Դϴ�.
    /// </summary>
    [Serializable]
    public class ItemData
    {
        [SerializeField] string _key;
        [SerializeField] bool _hasEquipped;

        /// <summary>
        /// �������� ���� Ű�Դϴ�.
        /// </summary>
        public string Key => _key;

        /// <summary>
        /// �������� ���� �����Դϴ�.
        /// </summary>
        public bool HasEquipped => _hasEquipped;

        public event Action OnHasEquippedChanged;

        /// <summary>
        /// ������ �����͸� �ʱ�ȭ�մϴ�.
        /// </summary>
        /// <param name="key">�������� ���� Ű</param>
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