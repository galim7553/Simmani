using System;
using GamePlay.Datas;
using GamePlay.Views;

namespace GamePlay.Presenters
{
    /// <summary>
    /// 대화를 관리하는 프레젠터.
    /// </summary>
    public class ConversationPresenter : ResourceDependentPresenterBase<IConversationModel, ConversationView>
    {
        int _curIndex = 0;

        /// <summary>현재 대화가 진행 중인지 여부.</summary>
        public bool IsPlaying { get; private set; } = false;

        /// <summary>대화가 완료되었을 때 발생하는 이벤트.</summary>

        public event Action OnCompleted;

        public ConversationPresenter(IConversationModel model, ConversationView view) : base(model, view)
        {
            StartConversation(model);
            _view.OnPanelButtonClicked += ExecuteNext;
        }

        /// <summary>
        /// 대화를 시작합니다.
        /// </summary>
        /// <param name="model">대화 모델.</param>
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
        /// 대화를 중단합니다.
        /// </summary>
        public void StopConversation()
        {
            _view.gameObject.SetActive(false);
            IsPlaying = false;
        }

        /// <summary>
        /// 대화의 다음 줄을 실행합니다.
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