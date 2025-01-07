using System;
using GamePlay.Datas;
using GamePlay.Views;

namespace GamePlay.Presenters
{
    /// <summary>
    /// ��ȭ�� �����ϴ� ��������.
    /// </summary>
    public class ConversationPresenter : ResourceDependentPresenterBase<IConversationModel, ConversationView>
    {
        int _curIndex = 0;

        /// <summary>���� ��ȭ�� ���� ������ ����.</summary>
        public bool IsPlaying { get; private set; } = false;

        /// <summary>��ȭ�� �Ϸ�Ǿ��� �� �߻��ϴ� �̺�Ʈ.</summary>

        public event Action OnCompleted;

        public ConversationPresenter(IConversationModel model, ConversationView view) : base(model, view)
        {
            StartConversation(model);
            _view.OnPanelButtonClicked += ExecuteNext;
        }

        /// <summary>
        /// ��ȭ�� �����մϴ�.
        /// </summary>
        /// <param name="model">��ȭ ��.</param>
        public void StartConversation(IConversationModel model)
        {
            IsPlaying = true;
            _view.gameObject.SetActive(true);

            _model = model;
            _curIndex = 0;

            _view.SetLetterWait(_model.Config.LetterSpan);
            ExecuteNext();
        }

        /// <summary>
        /// ��ȭ�� �ߴ��մϴ�.
        /// </summary>
        public void StopConversation()
        {
            _view.gameObject.SetActive(false);
            IsPlaying = false;
        }

        /// <summary>
        /// ��ȭ�� ���� ���� �����մϴ�.
        /// </summary>
        public void ExecuteNext()
        {
            if (IsPlaying == false) return;

            if (_view.IsPlaying == true)
                _view.ShowFullDialogue();
            else
            {
                if (_curIndex >= _model.Dialogues.Count)
                {
                    StopConversation();
                    OnCompleted?.Invoke();
                    return;
                }
                _view.PlayDialogue(_model.Dialogues[_curIndex]);
                _curIndex++;
            }
                
        }

        public override void Clear()
        {
            base.Clear();

            OnCompleted = null;
            _view.OnPanelButtonClicked -= ExecuteNext;
        }
    }
}