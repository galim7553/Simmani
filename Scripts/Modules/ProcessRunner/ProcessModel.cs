using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// ó�� ������ �۾��� �⺻ �����Դϴ�.
    /// </summary>
    public class ProcessModel : IProcessable
    {
        public IProcessable.ProcessType Type { get; private set; }
        public float Amount {get; private set;}
        public Action OnSuccess { get; private set; }
        public Action OnFailed {get; private set; }

        public ProcessModel(IProcessable.ProcessType type, float amount, Action onSuccess, Action onFailed)
        {
            Type = type;
            Amount = amount;
            OnSuccess = onSuccess;
            OnFailed = onFailed;
        }
    }
}